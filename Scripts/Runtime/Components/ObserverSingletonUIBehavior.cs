using System;
using UnityBase.Runtime.@base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityEngine.EventSystems;

namespace UnityBase.Runtime.@base.Scripts.Runtime.Components
{
    [Obsolete("Use class SingletonUIBehavior instead (more effective) together with attribute " + nameof(SingletonAttribute))]
    public abstract class ObserverSingletonUIBehavior<T> : UIBehaviour where T : ObserverSingletonUIBehavior<T>
    {
        public static T Singleton { get; private set; }

        protected override void OnEnable()
        {
            Singleton = (T) this;
        }

        protected override void OnDisable()
        {
            Singleton = null;
        }
    }
}