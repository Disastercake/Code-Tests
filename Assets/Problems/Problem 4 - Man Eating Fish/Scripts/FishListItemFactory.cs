using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManEatingFishProblem
{
    [DisallowMultipleComponent]
    public class FishListItemFactory : MonoBehaviour
    {
        [SerializeField]
        private FishListItemUI _listItemPrefab = null;

        [SerializeField]
        private Transform _contentParent = null;

        private List<FishListItemUI> _pool = new List<FishListItemUI>();

        private FishListItemUI Create()
        {
            var item = Instantiate(_listItemPrefab, _contentParent);
            _pool.Add(item);
            return item;
        }

        /// <summary>
        /// Will return a pooled item, or create a new one if there are none available in the pool.
        /// </summary>
        public FishListItemUI GetListItem()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i].gameObject.activeSelf == false)
                    return _pool[i];
            }

            return Create();
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
