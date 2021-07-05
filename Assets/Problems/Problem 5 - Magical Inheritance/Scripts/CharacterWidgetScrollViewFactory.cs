using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicalInheritance
{
    [DisallowMultipleComponent]
    public class CharacterWidgetScrollViewFactory : MonoBehaviour
    {
        [SerializeField]
        private MagicListItem _listItemPrefab = null;

        [SerializeField]
        private Transform _contentParent = null;

        private List<MagicListItem> _pool = new List<MagicListItem>();

        /// <summary>
        /// Will return a pooled item, or create a new one if there are none available in the pool.
        /// </summary>
        public MagicListItem GetListItem()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i].gameObject.activeSelf == false)
                    return _pool[i];
            }

            return Create();
        }

        private MagicListItem Create()
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
