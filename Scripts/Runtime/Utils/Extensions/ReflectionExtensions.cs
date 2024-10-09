using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions
{
    public static class ReflectionExtensions
    {
        public static (T, TA)? FirstWithAttribute<T, TA>(this IEnumerable<T> collection)
            where T : MemberInfo where TA : Attribute
        {
            var memberInfo = collection.FirstOrDefault(x => x.GetCustomAttribute<TA>() != null);
            if (memberInfo == null)
                return null;
            
            return (memberInfo, memberInfo.GetCustomAttribute<TA>());
        }

        public static IEnumerable<(T, TA)> WhereHasAttribute<T, TA>(this IEnumerable<T> collection) where T : MemberInfo where TA : Attribute
        {
            var filtered = collection.Where(x => x.GetCustomAttribute<TA>() != null);
            return filtered.Select(x => (x, x.GetCustomAttribute<TA>()));
        }
    }
}