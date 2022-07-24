using SnowMeltArcade.ProjectKitchen.Scenes.KitchenSetup;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class KitchenSetupScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

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

            for (var i = 0; i < 10; ++i)
            {
                var slot = workstationSlotTemplate.Instantiate();
                var workstation = workstationTemplate.Instantiate();
                
                slot.Add(workstation);
                availableWorkstations.Add(slot);
            }
        }
    }
}
