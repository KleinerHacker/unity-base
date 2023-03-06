using UnityBase.Runtime.@base.Scripts.Runtime.Components;
using UnityEngine;

namespace UnityBase.Runtime.@base.Scripts.Runtime
{
    public static class BehaviorSystem
    {
        public static MonoBehaviour GetHelper() => HelpBehavior.Singleton;
    }
}