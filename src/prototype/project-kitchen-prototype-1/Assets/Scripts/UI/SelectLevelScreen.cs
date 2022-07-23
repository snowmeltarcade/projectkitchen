using SnowMeltArcade.ProjectKitchen.Scenes.MenuScreens;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class SelectLevelScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            var buttonPlay = this.UIDocument.rootVisualElement.Q<Button>("buttonPlay");
            if (buttonPlay is null)
            {
                Debug.LogError("Failed to find button `buttonPlay`.");
                return;
            }

            buttonPlay.RegisterCallback<ClickEvent>(evt => { this.UIController.ShowLoadLevelScreen(); });
        }
    }
}
