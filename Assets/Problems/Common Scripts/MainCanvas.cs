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
            }
        }

        private void OnDestroy()
        {
            _backBut.onClick.RemoveListener(OnBackButton);
        }

        private void OnLevelWasLoaded(int level)
        {
            // Don't show back button at start scene or the title scene.
            _backBut.gameObject.SetActive(level > 1);
        }

        public void OnBackButton()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(START_SCENE_INDEX);
        }
    }
}
