using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunWithRectangles
{
    [DisallowMultipleComponent]
    public class RectangleUI : MonoBehaviour
    {
        private const string MSG_OVERLAPPED = "Overlapped.";
        private const string MSG_NOT_OVERLAPPED = "Not touching.";

        [SerializeField]
        private TMPro.TextMeshProUGUI _label_status = null;
        [SerializeField]
        private RectangleActor _sprite1 = null;
        [SerializeField]
        private RectangleActor _sprite2 = null;

        private bool _lastStatus = false;

        private void Awake()
        {
            _sprite1.Rect.OnRectChanged += CheckOverlap;
            _sprite2.Rect.OnRectChanged += CheckOverlap;
        }

        private void OnDestroy()
        {
            _sprite1.Rect.OnRectChanged -= CheckOverlap;
            _sprite2.Rect.OnRectChanged -= CheckOverlap;
        }

        private void CheckOverlap(Rectangle r)
        {
            Debug.Log("Checking...");

            var overlapped = Rectangle.IsOverlap(_sprite1.Rect, _sprite2.Rect);

            if (_lastStatus != overlapped)
            {
                _lastStatus = overlapped;
                _label_status.text = _lastStatus ? MSG_OVERLAPPED : MSG_NOT_OVERLAPPED;
            }
        }
    }
}
