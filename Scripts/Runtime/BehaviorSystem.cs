using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components;
using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime
{
    public static class BehaviorSystem
    {
        public static MonoBehaviour GetHelper() => HelpBehavior.Singleton;
    }
}