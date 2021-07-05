using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FunWithRectangles
{
    [RequireComponent(typeof(CommonScripts.ClampSpriteToViewport))]
    [RequireComponent(typeof(CommonScripts.InteractiveSprite))]
    [DisallowMultipleComponent]
    public class RectangleActor : MonoBehaviour
    {
        public Rectangle Rect { get; } = new Rectangle();

        void Update()
        {
            Rect.Set(
                transform.position.x, transform.position.y,
                transform.localScale.x, transform.localScale.y);
        }
    }
}
