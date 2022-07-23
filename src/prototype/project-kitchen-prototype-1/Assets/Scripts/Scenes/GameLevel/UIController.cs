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
        public UIDocument LevelMenuScreen;
        public UIDocument LevelSuccessScreen;

        private List<UIDocument> Screens { get; set; } = new();

        void Start()
        {
            this.Screens.Clear();
            this.Screens.AddRange(new[]
            {
                this.GameLevelScreen,
                this.LevelMenuScreen,
                this.LevelSuccessScreen,
            });

            this.HideAllScreens();

            this.ShowGameLevelScreen();
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

        public void ShowGameLevelScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.GameLevelScreen, true);
        }

        public void ShowLevelMenuScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.LevelMenuScreen, true);
        }

        public void ShowSelectLevelScreen()
        {
            this.HideAllScreens();

            SceneManager.LoadScene("Scenes/SelectLevel", LoadSceneMode.Single);
        }

        public void ShowLevelSuccessScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.LevelSuccessScreen, true);
        }

        public void ShowLoadLevelScreen()
        {
            this.HideAllScreens();

            SceneManager.LoadScene("Scenes/LoadLevel", LoadSceneMode.Single);
        }
    }
}
