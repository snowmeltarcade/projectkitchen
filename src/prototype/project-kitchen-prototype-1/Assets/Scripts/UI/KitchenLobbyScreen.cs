using SnowMeltArcade.ProjectKitchen.Scenes.KitchenLobby;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class KitchenLobbyScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            var buttonOK = this.UIDocument.rootVisualElement.Q<Button>("buttonOK");
            if (buttonOK is null)
            {
                Debug.LogError("Failed to find button `buttonOK`.");
                return;
            }

            buttonOK.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowGameLevelScreen(); });
        }
    }
}
