using UnityEngine;

namespace UnityBase.Runtime.@base.Scripts.Runtime.Utils
{
    public static class TextureUtils
    {
        public static Texture2D CreateSolidTexture(Color color)
        {
            var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            texture.SetPixel(0,0, color);
            texture.Apply();

            return texture;
        }
    }
}