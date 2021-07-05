using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MagicalInheritance
{
    [DisallowMultipleComponent]
    public class MagicListItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI _text = null;
        [SerializeField]
        private RectTransform _cursorPos = null;

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            CursorObject.Show(_cursorPos.position);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            CursorObject.Hide();
        }

        public void Set(string text)
        {
            _text.text = text;
        }
    }
}
