using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.Scenes.KitchenSetup
{
    public class UIController : MonoBehaviour
    {
        public UIDocument KitchenSetupScreen;

        private List<UIDocument> Screens { get; set; } = new();

        void Start()
        {
            this.Screens.Clear();
            this.Screens.AddRange(new[]
            {
                this.KitchenSetupScreen,
            });

            this.HideAllScreens();

            this.SetDocumentVisibility(this.KitchenSetupScreen, true);
        }

        private void HideAllScreens()
        {
            foreach (var screen in this.Screens)
            {
                this.SetDocumentVisibility(screen, false);
            }
        }

        private void SetDocumentVisibility(UIDocument document, bool visible)
        {
            document.rootVisualElement.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}
