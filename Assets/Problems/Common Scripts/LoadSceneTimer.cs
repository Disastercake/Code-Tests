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
            Invoke("LoadScene", TimeToLoad);
        }

        private void LoadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex);
        }
    }
}
