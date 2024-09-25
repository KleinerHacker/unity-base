using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions
{
    public static class RectExtensions
    {
        public static Rect Scale(this Rect rect, float scale) => 
            new Rect(rect.position, rect.size * scale);
        public static Rect Scale(this Rect rect, float scaleX, float scaleY) => 
            new Rect(rect.position.x, rect.position.y, rect.size.x * scaleX, rect.size.y * scaleY);

        public static Rect ScaleX(this Rect rect, float scaleX) => Scale(rect, scaleX, 1f);
        
        public static Rect ScaleY(this Rect rect, float scaleY) => Scale(rect, 1f, scaleY);

        public static Rect HalfX(this Rect rect) => rect.ScaleX(0.5f);

        public static Rect HalfY(this Rect rect) => rect.ScaleY(0.5f);
        
        public static Rect Shift(this Rect rect, float shiftX, float shiftY)
        {
            var shift = new Vector2(shiftX, shiftY);
            return new Rect(rect.position + shift, rect.size - shift);
        }

        public static Rect ShiftX(this Rect rect, float shiftX) => Shift(rect, shiftX, 0f);
        
        public static Rect ShiftY(this Rect rect, float shiftY) => Shift(rect, 0f, shiftY);
        
        public static Rect ShiftRelative(this Rect rect, float shiftX, float shiftY)
        {
            var relativeShift = new Vector2(shiftX, shiftY) * rect.size;
            return new Rect(rect.position + relativeShift, rect.size - relativeShift);
        }
        
        public static Rect ShiftRelativeX(this Rect rect, float shiftX) => ShiftRelative(rect, shiftX, 0f);
        
        public static Rect ShiftRelativeY(this Rect rect, float shiftY) => ShiftRelative(rect, 0f, shiftY);

        public static Rect ShiftHalfX(this Rect rect) => ShiftRelativeX(rect, 0.5f);
        
        public static Rect ShiftHalfY(this Rect rect) => ShiftRelativeY(rect, 0.5f);

        public static Rect Position(this Rect rect, Vector2 position) =>
            new Rect(position, rect.size);

        public static Rect PositionX(this Rect rect, float x) => Position(rect, new Vector2(x, rect.y));
        
        public static Rect PositionY(this Rect rect, float y) => Position(rect, new Vector2(rect.x, y));
        
        public static Rect Size(this Rect rect, Vector2 size) => 
            new Rect(rect.position, size);

        public static Rect Width(this Rect rect, float width) => Size(rect, new Vector2(width, rect.height));
        
        public static Rect Height(this Rect rect, float height) => Size(rect, new Vector2(rect.width, height));
    }
}