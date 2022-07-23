using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConnectToServerScreen : MonoBehaviour
{
    public UIController UIController;
    public UIDocument UIDocument;
    
    private void OnEnable()
    {
        var buttonBack = this.UIDocument.rootVisualElement.Q<Button>("buttonBack");
        if (buttonBack is null)
        {
            Debug.LogError("Failed to find button `buttonBack`.");
            return;
        }

        buttonBack.RegisterCallback<ClickEvent>(evt =>
        {
            this.UIController.ShowPlayerConnectOptionsScreen();
        });
        
        var buttonJoinGame = this.UIDocument.rootVisualElement.Q<Button>("buttonJoinGame");
        if (buttonJoinGame is null)
        {
            Debug.LogError("Failed to find button `buttonJoinGame`.");
            return;
        }

        buttonJoinGame.RegisterCallback<ClickEvent>(evt =>
        {
            this.UIController.ShowLoadLevelScreen();
        });
    }
}
