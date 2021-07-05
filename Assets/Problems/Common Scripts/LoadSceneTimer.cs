using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonScripts
{
    public class LoadSceneTimer : MonoBehaviour
    {
        public float TimeToLoad = 1f;
        public int SceneIndex = 1;

        void Start()
        {
            StartCoroutine(SceneTimer(TimeToLoad));
        }

        private IEnumerator SceneTimer(float time)
        {
            yield return new WaitForSeconds(time);
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex);
        }
    }
}
