using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonScripts
{
    [DisallowMultipleComponent]
    public class MainCanvas : MonoBehaviour
    {
        private static MainCanvas Instance = null;

        private const int START_SCENE_INDEX = 0;

        [SerializeField]
        UnityEngine.UI.Button _backBut = null;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                _backBut.onClick.AddListener(OnBackButton);
                _backBut.gameObject.SetActive(false);

                UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnLevelFinishedLoading;
            }
        }

        private void OnDestroy()
        {
            _backBut.onClick.RemoveListener(OnBackButton);

            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        private void OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            // Don't show back button at start scene or the title scene.
            _backBut.gameObject.SetActive(scene.buildIndex > 1);
        }

        public void OnBackButton()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(START_SCENE_INDEX);
        }
    }
}
