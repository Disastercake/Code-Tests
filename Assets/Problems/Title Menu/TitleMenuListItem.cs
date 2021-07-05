using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleMenuScripts
{
    [DisallowMultipleComponent]
    public class TitleMenuListItem : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI _text = null;

        private UnityEngine.UI.Button _btn = null;

        private ProblemSceneData _scene;

        private void Awake()
        {
            _btn = GetComponent<UnityEngine.UI.Button>();
            _btn.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _btn.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (_scene != null)
                UnityEngine.SceneManagement.SceneManager.LoadScene(_scene.Index);
        }

        public void Set(ProblemSceneData scene)
        {
            _scene = scene;
            _text.text = _scene.Title;
        }

        public void Reset()
        {
            _text.text = string.Empty;
            _scene = null;
        }
    }
}
