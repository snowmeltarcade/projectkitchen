using SnowMeltArcade.ProjectKitchen.Scenes.GameLevel;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class GameLevelScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            var buttonMenu = this.UIDocument.rootVisualElement.Q<Button>("buttonMenu");
            if (buttonMenu is null)
            {
                Debug.LogError("Failed to find button `buttonMenu`.");
                return;
            }

            buttonMenu.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowLevelMenuScreen(); });

            var buttonSuccess = this.UIDocument.rootVisualElement.Q<Button>("buttonSuccess");
            if (buttonSuccess is null)
            {
                Debug.LogError("Failed to find button `buttonSuccess`.");
                return;
            }

            buttonSuccess.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowLevelSuccessScreen(); });
        }
    }
}
