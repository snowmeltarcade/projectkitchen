using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartServerScreen : MonoBehaviour
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
        
        var buttonGo = this.UIDocument.rootVisualElement.Q<Button>("buttonGo");
        if (buttonGo is null)
        {
            Debug.LogError("Failed to find button `buttonGo`.");
            return;
        }

        buttonGo.RegisterCallback<ClickEvent>(evt =>
        {
            this.UIController.ShowSelectLevelScreen();
        });

        var listApprovePlayers = this.UIDocument.rootVisualElement.Q<ListView>("listApprovePlayers");
        if (listApprovePlayers is null)
        {
            Debug.LogError("Failed to find listview `listApprovePlayers`.");
            return;
        }

        const int itemCount = 5;
        var items = new List<string>(itemCount);
        for (int i = 1; i <= itemCount; i++)
        {
            items.Add(i.ToString());
        }

        var listItem = Resources.Load<VisualTreeAsset>("ApprovePlayerListItem");
        if (listItem is null)
        {
            Debug.LogError("Failed to find: `ApprovePlayerListItem.uxml`.");
            return;
        }
 
        Func<VisualElement> makeItem = () => listItem.Instantiate();
 
        Action<VisualElement, int> bindItem = (e, i) =>
        {
            var label = e.Q<Label>("labelPlayerHandle");
            label.text = $"Player `{items[i]}`";
        };
 
        listApprovePlayers.makeItem = makeItem;
        listApprovePlayers.bindItem = bindItem;
        listApprovePlayers.itemsSource = items;
        listApprovePlayers.selectionType = SelectionType.None;
    }
}
