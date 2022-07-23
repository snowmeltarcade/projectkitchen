using System.Collections;
using SnowMeltArcade.ProjectKitchen.Scenes.LoadLevel;
using UnityEngine;
using UnityEngine.UIElements;

namespace SnowMeltArcade.ProjectKitchen.UI
{
    public class LoadLevelScreen : MonoBehaviour
    {
        public UIController UIController;
        public UIDocument UIDocument;

        private void OnEnable()
        {
            this.StartCoroutine(this.LoadLevel());
        }

        private IEnumerator LoadLevel()
        {
            yield return new WaitForSeconds(1);

            this.UIController.ShowKitchenSetupScreen();
        }
    }
}
