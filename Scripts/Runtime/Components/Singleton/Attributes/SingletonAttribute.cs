using System;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes
{
    /// <summary>
    /// Represent the required attribute for <see cref="SingletonBehavior{T}"/> and <see cref="SingletonUIBehavior{T}"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : Attribute
    {
        /// <summary>
        /// Name of object in case of create new instance. Same names of singleton objects results in one merged game object.
        /// </summary>
        public string ObjectName { get; set; } = "";
        
        /// <summary>
        /// TRUE to destroy singleton if scene is unloading, otherwise FALSE (default)
        /// </summary>
        public bool CanDestroy { get; set; } = false;
        
        /// <summary>
        /// TRUE (default) to create instance immediately before loading first scene, otherwise FALSE
        /// </summary>
        public bool CreateImmediately { get; set; } = true;
    }
}