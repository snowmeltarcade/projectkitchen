using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
