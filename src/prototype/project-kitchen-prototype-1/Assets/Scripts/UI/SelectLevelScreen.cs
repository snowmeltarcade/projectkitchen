using SnowMeltArcade.ProjectKitchen.Scenes.SelectLevel;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class SelectLevelScreen : MonoBehaviour
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

            buttonBack.RegisterCallback<ClickEvent>(evt => {  });
        }
    }
}