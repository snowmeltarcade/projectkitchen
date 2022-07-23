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
        }
    }
}
