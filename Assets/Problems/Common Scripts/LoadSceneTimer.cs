using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonScripts
{
    [DisallowMultipleComponent]
    public class LoadSceneTimer : MonoBehaviour
    {
        public float TimeToLoad = 1f;
        public int SceneIndex = 1;

        void Start()
        {
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            yield return Yielders.WaitReal(TimeToLoad);
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex);
            yield break;
        }
    }
}
