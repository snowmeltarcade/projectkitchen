using System;
using System.Linq;
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

    internal record WorkstationSlotData(uint X, uint Y);

    internal record GridData(VisualElement Slot,
        bool HasWorkstation,
        bool IsAvailable,
        uint X,
        uint Y);
    
    public class KitchenSetupScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        public int GridWidth = 5;
        public int GridHeight = 5;

        private GridData[][] PlacedWorkstations; 
        
        [CanBeNull]
        private VisualElement SelectedWorkstation { get; set; }

        private void OnEnable()
        {
            this.PlacedWorkstations = new GridData[this.GridHeight][];
            for (var y = 0u; y < this.GridHeight; ++y)
            {
                this.PlacedWorkstations[y] = new GridData[this.GridWidth];

                for (var x = 0u; x < this.GridWidth; ++x)
                {
                    this.PlacedWorkstations[y][x] = new(null, false, false, x, y);
                }
            }
            
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

            for (var row = 0u; row < this.GridHeight; ++row)
            {
                // To view the workstation slots as a grid, we need to create the rows
                // manually. The rows are styled to display horizontally. The scroll
                // view itself is styled to display vertically.
                var horizontalContainer = new VisualElement();
                horizontalContainer.style.flexDirection = FlexDirection.Row;
                workstationGrid.Add(horizontalContainer);
                
                for (var column = 0u; column < this.GridWidth; ++column)
                {
                    var slot = workstationSlotTemplate.Instantiate();
                    slot.style.backgroundColor = new StyleColor(Color.gray);

                    this.PlacedWorkstations[row][column] = this.PlacedWorkstations[row][column] with
                    {
                        Slot = slot,
                    };

                    // we want to store the user data in the actual element that will be clicked,
                    // not the parent template container
                    var slotVisualElement = slot.Q<VisualElement>("slot");
                    if (slotVisualElement is null)
                    {
                        Debug.LogError("Failed to find element `slot`.");
                        return;
                    }
                    
                    slotVisualElement.userData = new WorkstationSlotData(column, row);
                
                    slot.RegisterCallback<ClickEvent>(e =>
                    {
                        var s = e.target as VisualElement;
                        if (s is null)
                        {
                            Debug.LogError("Failed to get slot.");
                            return;
                        }

                        // perhaps the user is clicking on a workstation that has already
                        // been placed
                        if (s.name != "slot")
                        {
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

            this.HighlightAvailableWorkstationSlots();
        }

        private void HighlightAvailableWorkstationSlots()
        {
            var takenSlots = from row in this.PlacedWorkstations
                from slot in row
                where slot.HasWorkstation
                select slot;

            foreach (var slot in takenSlots)
            {
                this.HighlightAreaAroundSlot(slot);
            }
        }

        private void HighlightAreaAroundSlot(GridData slot)
        {
            if (slot.X > 0)
            {
                this.HighlightSlot(slot.X - 1, slot.Y);
            }
            
            if (slot.X < this.GridWidth - 1)
            {
                this.HighlightSlot(slot.X + 1, slot.Y);
            }
            
            if (slot.Y > 0)
            {
                this.HighlightSlot(slot.X, slot.Y - 1);
            }
            
            if (slot.Y < this.GridHeight - 1)
            {
                this.HighlightSlot(slot.X, slot.Y + 1);
            }
        }

        private void HighlightSlot(uint x, uint y)
        {
            var gridData = this.PlacedWorkstations[y][x];
            gridData.Slot.style.backgroundColor = new StyleColor(Color.yellow);

            this.PlacedWorkstations[y][x] = gridData with
            {
                IsAvailable = true,
            };
        }

        private void UnselectWorkstation(VisualElement workstation)
        {
            workstation.style.backgroundColor = new StyleColor(Color.green);

            this.UnhighlightAvailableWorkstationSlots();
        }

        private void UnhighlightAvailableWorkstationSlots()
        {
            for (var y = 0; y < this.GridHeight; ++y)
            {
                for (var x = 0; x < this.GridWidth; ++x)
                {
                    this.PlacedWorkstations[y][x].Slot.style.backgroundColor = new StyleColor(Color.grey);

                    this.PlacedWorkstations[y][x] = this.PlacedWorkstations[y][x] with
                    {
                        IsAvailable = false,
                    };
                }
            }
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

            var slotData = this.PlacedWorkstations[data.Y][data.X];
            
            // we can only add one workstation per slot
            if (slotData.HasWorkstation)
            {
                return;
            }
            
            // we can only add a workstation in an available slot or if there are no
            // workstations placed
            var hasAnyWorkstations = from row in this.PlacedWorkstations
                from s in row
                select s.HasWorkstation;

            if (!slotData.IsAvailable && hasAnyWorkstations.Contains(true))
            {
                return;
            }

            // it looks like this method *replaces* the parent of the child,
            // so we do not need to manually remove this visual element from
            // its current parent
            slot.Add(this.SelectedWorkstation);

            this.PlacedWorkstations[data.Y][data.X] = slotData with
            {
                HasWorkstation = true,
            };
            
            this.UnselectWorkstation(this.SelectedWorkstation);
            this.SelectedWorkstation = null;
        }
    }
}
