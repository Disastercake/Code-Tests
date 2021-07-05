using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicalInheritance
{
    [RequireComponent(typeof(CharacterWidgetScrollViewFactory))]
    [DisallowMultipleComponent]
    public class CharacterWidgetScrollView : MonoBehaviour
    {
        private CharacterWidgetScrollViewFactory _factory = null;

        private void Awake()
        {
            _factory = GetComponent<CharacterWidgetScrollViewFactory>();
        }

        public void SetList(List<string> spells)
        {
            _factory.PoolAll();

            for (int i = 0; i < spells.Count; i++)
            {
                var button = _factory.GetListItem();
                button.Set(spells[i]);
            }
        }

        public void Clear()
        {
            _factory.PoolAll();
        }
    }
}
