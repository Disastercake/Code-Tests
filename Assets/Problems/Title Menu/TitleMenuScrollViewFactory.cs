using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleMenuScripts
{
    [DisallowMultipleComponent]
    public class TitleMenuScrollViewFactory : MonoBehaviour
    {
        [SerializeField]
        private TitleMenuListItem _listItemPrefab = null;

        [SerializeField]
        private Transform _contentParent = null;

        private List<TitleMenuListItem> _pool = new List<TitleMenuListItem>();

        /// <summary>
        /// Will return a pooled item, or create a new one if there are none available in the pool.
        /// </summary>
        public TitleMenuListItem GetListItem()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i].gameObject.activeSelf == false)
                    return _pool[i];
            }

            return Create();
        }

        private TitleMenuListItem Create()
        {
            var item = Instantiate(_listItemPrefab, _contentParent);
            _pool.Add(item);
            return item;
        }

        public void PoolAll()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                _pool[i].gameObject.SetActive(false);
            }
        }
    }
}
