using SnowMeltArcade.ProjectKitchen.Scenes.MenuScreens;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class PlayerConnectOptionsScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            var buttonStartGame = this.UIDocument.rootVisualElement.Q<Button>("buttonStartGame");
            if (buttonStartGame is null)
            {
                Debug.LogError("Failed to find button `buttonStartGame`.");
                return;
            }

            buttonStartGame.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowStartServerScreen(); });

            var buttonJoinGame = this.UIDocument.rootVisualElement.Q<Button>("buttonJoinGame");
            if (buttonJoinGame is null)
            {
                Debug.LogError("Failed to find button `buttonJoinGame`.");
                return;
            }

            buttonJoinGame.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowConnectToServerScreen(); });

            var buttonBack = this.UIDocument.rootVisualElement.Q<Button>("buttonBack");
            if (buttonBack is null)
            {
                Debug.LogError("Failed to find button `buttonBack`.");
                return;
            }

            buttonBack.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowMainMenuScreen(); });
        }
    }
}
