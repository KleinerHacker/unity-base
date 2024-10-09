using System;
using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Auto
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : PropertyAttribute
    {
        public InjectionTime Time { get; set; } = InjectionTime.Awake;
        public InjectionPlace Place { get; set; } = InjectionPlace.Current;
    }

    public enum InjectionTime
    {
        Awake,
        Enable,
        Start
    }

    public enum InjectionPlace
    {
        Current,
        Children,
        Parents
    }
}