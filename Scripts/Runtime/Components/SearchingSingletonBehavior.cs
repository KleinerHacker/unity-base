using System;
using UnityBase.Runtime.@base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityEngine;

namespace UnityBase.Runtime.@base.Scripts.Runtime.Components
{
    [Obsolete("Use class SingletonBehavior instead (more effective) together with attribute " + nameof(SingletonAttribute))]
    public abstract class SearchingSingletonBehavior<T> : MonoBehaviour where T : SearchingSingletonBehavior<T>
    {
        public static T Singleton => FindObjectOfType<T>();
    }
}