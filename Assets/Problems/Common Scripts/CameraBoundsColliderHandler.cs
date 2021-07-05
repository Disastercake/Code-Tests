using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonScripts
{
    [DisallowMultipleComponent]
    public class CameraBoundsColliderHandler : MonoBehaviour
    {
        private Transform _top = null;
        private Transform _bot = null;
        private Transform _left = null;
        private Transform _right = null;

        private void Awake()
        {
            _top = CreateSide("top");
            _bot = CreateSide("bot");
            _left = CreateSide("left");
            _right = CreateSide("right");

            ClampToCameraView();
        }

        private Transform CreateSide(string side)
        {
            var t = new GameObject().transform;
            t.gameObject.AddComponent<BoxCollider2D>();
            t.SetParent(transform);
            t.name = side;
            return t;
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

            float height = Mathf.Abs(cam_topRight.y - cam_botLeft.y);
            float width = Mathf.Abs(cam_topRight.x - cam_botLeft.x);

            _right.position = new Vector3(  cam_topRight.x,                     cam_topRight.y - (height/2),    0f);
            _left.position = new Vector3(   cam_botLeft.x,                      cam_topRight.y - (height / 2),  0f);
            _top.position = new Vector3(    cam_topRight.x - (width / 2),       cam_topRight.y,                 0f);
            _bot.position = new Vector3(    cam_topRight.x - (width / 2),       cam_botLeft.y,                  0f);

            _right.localScale = new Vector3(0.1f, height, 1f);
            _left.localScale = new Vector3(0.1f, height, 1f);
            _top.localScale = new Vector3(width, 0.1f, 1f);
            _bot.localScale = new Vector3(width, 0.1f, 1f);
        }
    }
}
