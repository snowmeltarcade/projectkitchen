using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.Scenes.GameLevel
{
    public class UIController : MonoBehaviour
    {
        public UIDocument GameLevelScreen;

        private List<UIDocument> Screens { get; set; } = new();

        void Start()
        {
            this.Screens.Clear();
            this.Screens.AddRange(new[]
            {
                this.GameLevelScreen,
            });

            this.HideAllScreens();

            this.SetDocumentVisibility(this.GameLevelScreen, true);
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
