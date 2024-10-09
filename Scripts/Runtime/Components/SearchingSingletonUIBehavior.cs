using System;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityEngine.EventSystems;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components
{
    [Obsolete("Use class SingletonUIBehavior instead (more effective) together with attribute " + nameof(SingletonAttribute))]
    public abstract class SearchingSingletonUIBehavior<T> : UIBehaviour where T : SearchingSingletonUIBehavior<T>
    {
        public static T Singleton => FindObjectOfType<T>();
    }
}