using UnityEngine;

namespace FunWithRectangles
{
    public class Rectangle
    {
        #region Getters and Member Variables

        public float X { get; private set; } = 0;
        public float Y { get; private set; } = 0;
        public float Width { get; private set; } = 0;
        public float Height { get; private set; } = 0;

        public Vector2 TopRight { get { return _topRight; } }
        private Vector2 _topRight = Vector2.zero;

        public Vector2 BotRight { get { return _botRight; } }
        private Vector2 _botRight = Vector2.zero;

        public Vector2 TopLeft { get { return _topLeft; } }
        private Vector2 _topLeft = Vector2.zero;

        public Vector2 BotLeft { get { return _botLeft; } }
        private Vector2 _botLeft = Vector2.zero;

        /// <summary>
        /// Returns in clockwise order: TopRight, BotRight, BotLeft, TopLeft
        /// </summary>
        public Vector2[] GetCorners()
        {
            return new Vector2[] { TopRight, BotRight, BotLeft, TopLeft };
        }

        #endregion

        #region Setters and Constructors

        public Rectangle()
        {

        }

        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            UpdateCorners();
        }

        public void Set(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;

            UpdateCorners();
        }

        #endregion

        #region Local Methods

        /// <summary>
        /// Returns true if the rectangles overlap.
        /// </summary>
        public bool IsOverlap(Rectangle rect)
        {
            return IsOverlap(this, rect);
        }

        /// <summary>
        /// Cache the corners so not creating new Vector3's on the spot.
        /// </summary>
        private void UpdateCorners()
        {
            _topRight.Set(X + (Width / 2f), Y + (Height / 2f));
            _botRight.Set(X + (Width / 2f), Y - (Height / 2f));
            _topLeft.Set(X - (Width / 2f), Y + (Height / 2f));
            _botLeft.Set(X - (Width / 2f), Y - (Height / 2f));
        }

        public bool IsPointInside(Vector2 point)
        {
            return (point.x > BotLeft.x && point.y > BotLeft.y &&
                    point.x < TopRight.x && point.y < TopRight.y);
        }

        #endregion

        #region Static

        /// <summary>
        /// Returns true if the rectangles overlap.
        /// </summary>
        public static bool IsOverlap(Rectangle rectA, Rectangle rectB)
        {
            if (rectA == null || rectB == null) return false;

            var cornersA = rectA.GetCorners();
            var cornersB = rectB.GetCorners();

            // Are they the same size?
            bool sameShape = true;

            for (int i = 0; i < cornersA.Length; i++)
            {
                if (cornersA[i] != cornersB[i])
                {
                    sameShape = false;
                    break;
                }
            }

            if (sameShape) return true;

            // Is any point of A inside B?
            for (int i = 0; i < cornersA.Length; i++)
            {
                if (rectB.IsPointInside(cornersA[i]))
                    return true;
            }

            // Is any point of B inside A?
            for (int i = 0; i < cornersB.Length; i++)
            {
                if (rectA.IsPointInside(cornersB[i]))
                    return true;
            }

            // If here, then no points were inside a rect.
            return false;
        }

        #endregion
    }
}
