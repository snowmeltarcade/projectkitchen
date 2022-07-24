using System;
using JetBrains.Annotations;
using SnowMeltArcade.ProjectKitchen.Scenes.KitchenSetup;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    internal enum WorkstationType
    {
        Pantry,
        Chopping,
        PlateCupboard,
        Serving,
    }
    
    internal record WorkstationData(string Name, WorkstationType Type);

    internal record WorkstationSlotData(bool HasWorkstation);
    
    public class KitchenSetupScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        [CanBeNull]
        private VisualElement SelectedWorkstation { get; set; }

        private void OnEnable()
        {
            var buttonDone = this.UIDocument.rootVisualElement.Q<Button>("buttonDone");
            if (buttonDone is null)
            {
                Debug.LogError("Failed to find button `buttonDone`.");
                return;
            }

            buttonDone.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowKitchenLobbyScreen(); });

            var workstationSlotTemplate = Resources.Load<VisualTreeAsset>("WorkstationSlot");
            if (workstationSlotTemplate is null)
            {
                Debug.LogError("Failed to find template `WorkstationSlot`.");
                return;
            }
            
            var workstationTemplate = Resources.Load<VisualTreeAsset>("Workstation");
            if (workstationTemplate is null)
            {
                Debug.LogError("Failed to find template `Workstation`.");
                return;
            }
            
            this.SetupWorkstations(workstationSlotTemplate, workstationTemplate);
            
            this.SetupAvailableWorkstations(workstationSlotTemplate, workstationTemplate);

            this.SetupGridWorkstations(workstationSlotTemplate, workstationTemplate);
        }

        private void SetupGridWorkstations(VisualTreeAsset workstationSlotTemplate, VisualTreeAsset workstationTemplate)
        {
            var workstationGrid = this.UIDocument.rootVisualElement.Q<VisualElement>("workstationGrid");
            if (workstationGrid is null)
            {
                Debug.LogError("Failed to find element `workstationGrid`.");
                return;
            }
            
            workstationGrid.Clear();

            for (var row = 0; row < 5; ++row)
            {
                // To view the workstation slots as a grid, we need to create the rows
                // manually. The rows are styled to display horizontally. The scroll
                // view itself is styled to display vertically.
                var horizontalContainer = new VisualElement();
                horizontalContainer.style.flexDirection = FlexDirection.Row;
                workstationGrid.Add(horizontalContainer);
                
                for (var column = 0; column < 5; ++column)
                {
                    var slot = workstationSlotTemplate.Instantiate();

                    // we want to store the user data in the actual element that will be clicked,
                    // not the parent template container
                    var slotVisualElement = slot.Q<VisualElement>("slot");
                    if (slotVisualElement is null)
                    {
                        Debug.LogError("Failed to find element `slot`.");
                        return;
                    }
                    
                    slotVisualElement.userData = new WorkstationSlotData(false);
                
                    slot.RegisterCallback<ClickEvent>(e =>
                    {
                        var s = e.target as VisualElement;
                        if (s is null)
                        {
                            Debug.LogError("Failed to get slot.");
                            return;
                        }

                        this.PlaceSelectedWorkstation(s);
                    });

                    horizontalContainer.Add(slot);
                }
            }
        }
        
        private void SetupWorkstations(VisualTreeAsset workstationSlotTemplate, VisualTreeAsset workstationTemplate)
        {
            var requiredWorkstations = this.UIDocument.rootVisualElement.Q<VisualElement>("requiredWorkstations");
            if (requiredWorkstations is null)
            {
                Debug.LogError("Failed to find element `requiredWorkstations`.");
                return;
            }
            
            requiredWorkstations.Clear();

            for (var i = 0; i < 4; ++i)
            {
                var slot = workstationSlotTemplate.Instantiate();
                var workstation = workstationTemplate.Instantiate();
                
                slot.Add(workstation);
                requiredWorkstations.Add(slot);
            }
        }

        private void SetupAvailableWorkstations(VisualTreeAsset workstationSlotTemplate, VisualTreeAsset workstationTemplate)
        {
            var availableWorkstations = this.UIDocument.rootVisualElement.Q<VisualElement>("availableWorkstations");
            if (availableWorkstations is null)
            {
                Debug.LogError("Failed to find element `availableWorkstations`.");
                return;
            }
            
            availableWorkstations.Clear();

            foreach (var type in (WorkstationType[])Enum.GetValues(typeof(WorkstationType)))
            {
                var slot = workstationSlotTemplate.Instantiate();
                var workstation = workstationTemplate.Instantiate();

                WorkstationData workstationData = new(type.ToString(), type);
                workstation.userData = workstationData;
                
                workstation.tooltip = workstationData.Name;
                
                workstation.RegisterCallback<ClickEvent>(e =>
                {
                    var w = e.target as VisualElement;
                    if (w is null)
                    {
                        Debug.LogError("Failed to get workstation.");
                        return;
                    }
                    
                    this.SelectAvailableWorkstation(w);
                });
                
                slot.Add(workstation);
                availableWorkstations.Add(slot);
            }
        }

        private void SelectAvailableWorkstation(VisualElement workstation)
        {
            if (this.SelectedWorkstation is not null)
            {
                this.SelectedWorkstation.style.backgroundColor = new StyleColor(Color.green);
            }

            this.SelectedWorkstation = workstation;
            this.SelectedWorkstation.style.backgroundColor = new StyleColor(Color.red);
        }

        private void UnselectWorkstation(VisualElement workstation)
        {
            workstation.style.backgroundColor = new StyleColor(Color.green);
        }

        private void PlaceSelectedWorkstation(VisualElement slot)
        {
            if (this.SelectedWorkstation is null)
            {
                return;
            }

            WorkstationSlotData data = slot.userData as WorkstationSlotData;
            if (data is null)
            {
                Debug.LogError("Failed to get workstation slot data.");
                return;
            }
            
            // we can only add one workstation per slot
            if (data.HasWorkstation)
            {
                return;
            }

            // it looks like this method *replaces* the parent of the child,
            // so we do not need to manually remove this visual element from
            // its current parent
            slot.Add(this.SelectedWorkstation);

            slot.userData = data with { HasWorkstation = true };
            
            this.UnselectWorkstation(this.SelectedWorkstation);
            this.SelectedWorkstation = null;
        }
    }
}
