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
}
