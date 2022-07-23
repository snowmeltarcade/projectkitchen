using SnowMeltArcade.ProjectKitchen.Scenes.GameLevel;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class LevelMenuScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            var buttonBack = this.UIDocument.rootVisualElement.Q<Button>("buttonBack");
            if (buttonBack is null)
            {
                Debug.LogError("Failed to find button `buttonBack`.");
                return;
            }

            buttonBack.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowGameLevelScreen(); });
            
            var buttonPause = this.UIDocument.rootVisualElement.Q<Button>("buttonPause");
            if (buttonPause is null)
            {
                Debug.LogError("Failed to find button `buttonPause`.");
                return;
            }

            buttonPause.RegisterCallback<ClickEvent>(evt =>
            {
                buttonPause.text = buttonPause.text == "Pause" ? "Resume" : "Pause";
            });
            
            var buttonExit = this.UIDocument.rootVisualElement.Q<Button>("buttonExit");
            if (buttonExit is null)
            {
                Debug.LogError("Failed to find button `buttonExit`.");
                return;
            }

            buttonExit.RegisterCallback<ClickEvent>(evt =>
            {
                this.UIController.ShowSelectLevelScreen();
            });
        }
    }
}
