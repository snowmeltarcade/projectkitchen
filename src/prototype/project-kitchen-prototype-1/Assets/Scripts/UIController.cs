using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public UIDocument SplashScreens;
    public UIDocument TitleScreen;
    public UIDocument PlayerInformationScreen;
    public UIDocument MainMenuScreen;
    public UIDocument OptionsScreen;
    public UIDocument PlayerConnectOptionsScreen;
    public UIDocument SelectLevelScreen;
    public UIDocument ConnectToServerScreen;
    public UIDocument StartServerScreen;
    public UIDocument LoadLevelScreen;

    private List<UIDocument> Screens { get; set; } = new();
        
    // Start is called before the first frame update
    void Start()
    {
        this.Screens.Clear();
        this.Screens.AddRange(new []
        {
            this.SplashScreens,
            this.TitleScreen,
            this.PlayerInformationScreen,
            this.MainMenuScreen,
            this.OptionsScreen,
            this.PlayerConnectOptionsScreen,
            this.SelectLevelScreen,
            this.ConnectToServerScreen,
            this.StartServerScreen,
            this.LoadLevelScreen
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

        this.SetDocumentVisibility(this.SelectLevelScreen, true);
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

        this.SetDocumentVisibility(this.LoadLevelScreen, true);   
    }
}
