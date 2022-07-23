using SnowMeltArcade.ProjectKitchen.Scenes.GameLevel;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class LevelFailedScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            var buttonSelectLevel = this.UIDocument.rootVisualElement.Q<Button>("buttonSelectLevel");
            if (buttonSelectLevel is null)
            {
                Debug.LogError("Failed to find button `buttonSelectLevel`.");
                return;
            }

            buttonSelectLevel.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowSelectLevelScreen(); });
            
            var buttonRetry = this.UIDocument.rootVisualElement.Q<Button>("buttonRetry");
            if (buttonRetry is null)
            {
                Debug.LogError("Failed to find button `buttonRetry`.");
                return;
            }

            buttonRetry.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowLoadLevelScreen(); });
        }
    }
}
