using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommonScripts
{
    [DisallowMultipleComponent]
    public class ClampSpriteToViewport : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer = null;

        private void Awake()
        {
            if (_renderer == null)
            {
                if (TryGetComponent(out _renderer) == false)
                {
                    Debug.LogError($"SpriteRenderer not assigned or attached to {gameObject.name}.  Cannot clamp to viewport.");
                    enabled = false;
                }
            }
        }

        private void Update()
        {
            ClampToCameraView();
        }

        private void ClampToCameraView()
        {
            var pos = transform.position;

            var cam_topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
            var cam_botLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));

            Vector3 topRight = _renderer.transform.TransformPoint(_renderer.sprite.bounds.max);
            Vector3 botLeft = _renderer.transform.TransformPoint(_renderer.sprite.bounds.min);

            if (topRight.x > cam_topRight.x)
                pos.x -= Mathf.Abs(topRight.x - cam_topRight.x);

            if (topRight.y > cam_topRight.y)
                pos.y -= Mathf.Abs(topRight.y - cam_topRight.y);

            if (botLeft.x < cam_botLeft.x)
                pos.x += Mathf.Abs(botLeft.x - cam_botLeft.x);

            if (botLeft.y < cam_botLeft.y)
                pos.y += Mathf.Abs(botLeft.y - cam_botLeft.y);

            if (pos != transform.position)
                transform.position = pos;
        }
    }
}
