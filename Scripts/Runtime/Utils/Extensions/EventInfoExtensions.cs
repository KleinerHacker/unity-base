using System;
using System.Reflection;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions
{
    public static class EventInfoExtensions
    {
        public static void Raise<TEventArgs>(this EventInfo eventInfo, object source, TEventArgs eventArgs) where TEventArgs : EventArgs
        {
            var eventDelegate = (MulticastDelegate)source.GetType().GetField(eventInfo.Name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(source);
            if (eventDelegate != null)
            {
                foreach (var handler in eventDelegate.GetInvocationList())
                {
                    handler.Method.Invoke(handler.Target, new object[] { source, eventArgs });
                }
            }
        }
    }
}