using System;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components
{
    [Obsolete("Use class SingletonBehavior instead (more effective) together with attribute " + nameof(SingletonAttribute))]
    public abstract class ObserverSingletonBehavior<T> : MonoBehaviour where T : ObserverSingletonBehavior<T>
    {
        public static T Singleton { get; private set; }
        
        public static event EventHandler SingletonSpawned;
        public static event EventHandler SingletonDestroying;

        protected virtual void OnEnable()
        {
            Singleton = (T) this;
            SingletonSpawned?.Invoke(null, EventArgs.Empty);
        }

        protected virtual void OnDisable()
        {
            SingletonDestroying?.Invoke(null, EventArgs.Empty);
            Singleton = null;
        }
    }
}