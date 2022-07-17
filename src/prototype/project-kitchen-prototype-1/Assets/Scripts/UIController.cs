using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public UIDocument SplashScreens;
    public UIDocument TitleScreen;

    private List<UIDocument> Screens { get; set; } = new();
        
    // Start is called before the first frame update
    void Start()
    {
        this.Screens.Clear();
        this.Screens.AddRange(new []{ this.SplashScreens, this.TitleScreen });
        
        this.HideAllScreens();

        this.SetDocumentVisibility(this.SplashScreens, true);

        this.StartCoroutine(this.ShowTitleScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        document.enabled = visible;
    }

    private IEnumerator ShowTitleScreen()
    {
        yield return new WaitForSeconds(2);
        
        this.HideAllScreens();

        this.SetDocumentVisibility(this.TitleScreen, true);
    }
}
