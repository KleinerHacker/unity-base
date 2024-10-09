using System;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions
{
    public static class ObjectExtensions
    {
        public static T[] ToSingleArray<T>(this T obj) =>
            obj == null ? Array.Empty<T>() : new[] { obj };

        public static T[] ToSingleArray<T>(this T? obj) where T : struct =>
            obj == null ? Array.Empty<T>() : new[] { obj.Value };
    }
}