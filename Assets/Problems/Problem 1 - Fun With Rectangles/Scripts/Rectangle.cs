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

        /// <summary>
        /// Top right corner of the triangle.
        /// </summary>
        public Vector2 TopRight { get { return new Vector2(X + (Width / 2f), Y + (Height / 2f)); } }

        /// <summary>
        /// Bottom right corner of the triangle.
        /// </summary>
        public Vector2 BotRight { get { return new Vector2(X + (Width / 2f), Y - (Height / 2f)); } }

        /// <summary>
        /// Top left corner of the triangle.
        /// </summary>
        public Vector2 TopLeft { get { return new Vector2(X - (Width / 2f), Y + (Height / 2f)); } }

        /// <summary>
        /// Bottom left corner of the triangle.
        /// </summary>
        public Vector2 BotLeft { get { return new Vector2(X - (Width / 2f), Y - (Height / 2f)); } }

        /// <summary>
        /// Returns all four corners of the rectangle in clockwise order: TopRight, BotRight, BotLeft, TopLeft
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
            Set(x, y, width, height);
        }

        public void Set(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        #endregion

        #region Local Methods

        /// <summary>
        /// Returns true if this and the target Rectangle overlap.
        /// </summary>
        public bool IsOverlap(Rectangle rect)
        {
            return IsOverlap(this, rect);
        }

        /// <summary>
        /// Returns true if the specific point is inside this rectangle.
        /// </summary>
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
