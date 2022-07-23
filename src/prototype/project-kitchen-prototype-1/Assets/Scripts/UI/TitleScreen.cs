using SnowMeltArcade.ProjectKitchen.Scenes.MenuScreens;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class TitleScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            this.UIDocument.rootVisualElement.RegisterCallback<MouseDownEvent>(evt =>
            {
                this.UIController.ShowPlayerInformationScreen();
            });
        }
    }
}
