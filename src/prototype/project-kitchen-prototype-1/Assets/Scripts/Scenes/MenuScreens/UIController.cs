using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.Scenes.MenuScreens
{
    public class UIController : MonoBehaviour
    {
        public UIDocument SplashScreens;
        public UIDocument TitleScreen;
        public UIDocument PlayerInformationScreen;
        public UIDocument MainMenuScreen;
        public UIDocument OptionsScreen;
        public UIDocument PlayerConnectOptionsScreen;
        public UIDocument ConnectToServerScreen;
        public UIDocument StartServerScreen;

        private List<UIDocument> Screens { get; set; } = new();

        // Start is called before the first frame update
        void Start()
        {
            this.Screens.Clear();
            this.Screens.AddRange(new[]
            {
                this.SplashScreens,
                this.TitleScreen,
                this.PlayerInformationScreen,
                this.MainMenuScreen,
                this.OptionsScreen,
                this.PlayerConnectOptionsScreen,
                this.ConnectToServerScreen,
                this.StartServerScreen,
            });

            this.HideAllScreens();

            this.SetDocumentVisibility(this.SplashScreens, true);

            this.StartCoroutine(this.ShowTitleScreen());
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

        private IEnumerator ShowTitleScreen()
        {
            yield return new WaitForSeconds(1);

            this.HideAllScreens();

            this.SetDocumentVisibility(this.TitleScreen, true);
        }

        public void ShowPlayerInformationScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.PlayerInformationScreen, true);
        }

        public void ShowMainMenuScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.MainMenuScreen, true);
        }

        public void ShowOptionsScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.OptionsScreen, true);
        }

        public void ShowPlayerConnectOptionsScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.PlayerConnectOptionsScreen, true);
        }

        public void ShowSelectLevelScreen()
        {
            this.HideAllScreens();

            SceneManager.LoadScene("Scenes/SelectLevel", LoadSceneMode.Single);
        }

        public void ShowConnectToServerScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.ConnectToServerScreen, true);
        }

        public void ShowStartServerScreen()
        {
            this.HideAllScreens();

            this.SetDocumentVisibility(this.StartServerScreen, true);
        }

        public void ShowLoadLevelScreen()
        {
            this.HideAllScreens();

            SceneManager.LoadScene("Scenes/LoadLevel", LoadSceneMode.Single);
        }
    }
}
