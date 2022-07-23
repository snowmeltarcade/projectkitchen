using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectLevelScreen : MonoBehaviour
{
    public UIController UIController;
    public UIDocument UIDocument;
    
    private void OnEnable()
    {
        var buttonPlay = this.UIDocument.rootVisualElement.Q<Button>("buttonPlay");
        if (buttonPlay is null)
        {
            Debug.LogError("Failed to find button `buttonPlay`.");
            return;
        }

        buttonPlay.RegisterCallback<ClickEvent>(evt =>
        {
            this.UIController.ShowStartServerScreen();
        });
    }
}
