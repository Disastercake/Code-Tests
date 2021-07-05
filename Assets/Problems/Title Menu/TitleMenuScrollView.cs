using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleMenuScripts
{
    [RequireComponent(typeof(TitleMenuScrollViewFactory))]
    [DisallowMultipleComponent]
    public class TitleMenuScrollView : MonoBehaviour
    {
        [SerializeField]
        private List<ProblemSceneData> _scenes = new List<ProblemSceneData>();

        private TitleMenuScrollViewFactory _factory = null;

        private void Awake()
        {
            _factory = GetComponent<TitleMenuScrollViewFactory>();
        }

        private void Start()
        {
            SetList(_scenes);
        }

        public void SetList(List<ProblemSceneData> scenes)
        {
            _factory.PoolAll();

            for (int i = 0; i < scenes.Count; i++)
            {
                var button = _factory.GetListItem();
                button.Set(scenes[i]);
            }
        }

        public void Clear()
        {
            _factory.PoolAll();
        }
    }
}
