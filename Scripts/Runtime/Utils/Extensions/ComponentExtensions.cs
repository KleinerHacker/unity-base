using UnityBase.Runtime.@base.Scripts.Runtime.Types;
using UnityEngine;

namespace UnityBase.Runtime.@base.Scripts.Runtime.Utils.Extensions
{
    public static class ComponentExtensions
    {
        public static T[] FindComponents<T>(this Component component, TreeSearchDirection direction = TreeSearchDirection.All) => 
            component.gameObject.FindComponents<T>(direction);

        public static T FindComponent<T>(this Component component, TreeSearchDirection direction = TreeSearchDirection.All) => 
            component.gameObject.FindComponent<T>(direction);
    }
}