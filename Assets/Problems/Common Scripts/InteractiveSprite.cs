using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CommonScripts
{
    public class InteractiveSprite : MonoBehaviour,
        UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.IDragHandler,
        UnityEngine.EventSystems.IPointerClickHandler
    {
        public bool Draggable = true;

        public UnityEngine.Events.UnityEvent _OnClick;

        /// <summary>
        /// The offset where the mouse clicked the square.
        /// This will prevent snapping the center to the mouse.
        /// </summary>
        private Vector3 _clickOffset = Vector3.zero;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            if (!Draggable) return;

            Vector3 globalMousePos = eventData.pressEventCamera.ScreenToWorldPoint(eventData.position);
            globalMousePos.z = transform.position.z;
            _clickOffset = transform.position - globalMousePos;
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (!Draggable) return;

            SetDraggedPosition(eventData);
        }

        private void SetDraggedPosition(PointerEventData eventData)
        {
            var rt = GetComponent<Transform>();
            Vector3 globalMousePos = eventData.pressEventCamera.ScreenToWorldPoint(eventData.position);
            globalMousePos.z = transform.position.z;
            rt.position = globalMousePos + _clickOffset;
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            _OnClick.Invoke();
        }
    }
}
