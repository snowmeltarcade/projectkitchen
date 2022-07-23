using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.Scenes.SelectLevel
{
    public class UIController : MonoBehaviour
    {
        public UIDocument SelectLevelScreen;

        private List<UIDocument> Screens { get; set; } = new();

        void Start()
        {
            this.Screens.Clear();
            this.Screens.AddRange(new[]
            {
                this.SelectLevelScreen,
            });

            this.HideAllScreens();

            this.SetDocumentVisibility(this.SelectLevelScreen, true);
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

        public void ShowStartServerScreen()
        {
            this.HideAllScreens();

            SceneManager.LoadScene("Scenes/MenuScreens", LoadSceneMode.Single);
        }

        public void ShowLoadLevelScreen()
        {
            this.HideAllScreens();

            SceneManager.LoadScene("Scenes/LoadLevel", LoadSceneMode.Single);
        }
    }
}
