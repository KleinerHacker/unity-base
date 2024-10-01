using System;
using System.Linq;
using System.Reflection;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions;
using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton
{
    public abstract class SingletonBehavior<T> : MonoBehaviour where T : SingletonBehavior<T>
    {
        private static T instance;
        private static object lockObject = new();
        private static bool applicationIsQuitting = false;

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed on application quit." +
                                     " Won't create again - returning null.");
                    return null;
                }

                lock (lockObject)
                {
                    //Instance already exists in cache?
                    if (instance != null)
                        return instance;

                    //Try to find existing instance of object type
                    instance = TryFindExistingInstance();

                    //Exists instance in scene?
                    if (instance != null)
                    {
#if PCSOFT_SINGLETON_LOGGING
                        Debug.Log("[Singleton] Find already existing instance of type " + typeof(T).FullName);
#endif
                        return instance;
                    }

                    //Create new instance
                    instance = CreateNewInstance();
                    return instance;
                }
            }
        }

        private static T TryFindExistingInstance()
        {
#if PCSOFT_SINGLETON_LOGGING
            Debug.Log("[Singleton] Try to find existing instance of type " + typeof(T).FullName + "...");
#endif

            var existingInstance = FindFirstObjectByType<T>();

            if (FindObjectsByType<T>(FindObjectsSortMode.None).Length > 1)
            {
                Debug.LogWarning("[Singleton] Something went really wrong " +
                                 " - there should never be more than 1 singleton!" +
                                 " Reopenning the scene might fix it.");
            }

            return existingInstance;
        }

        private static T CreateNewInstance()
        {
#if PCSOFT_SINGLETON_LOGGING
            Debug.Log("[Singleton] Create new instance of type " + typeof(T).FullName + "...");
#endif

            var descriptionAttr = typeof(T).GetCustomAttribute<SingletonAttribute>(true);

            var go = new GameObject(descriptionAttr.ObjectName + " (Singleton)");
            if (!descriptionAttr.CanDestroy)
            {
#if PCSOFT_SINGLETON_LOGGING
                Debug.Log("[Singleton] Do not destroy type " + typeof(T).FullName + "!");
#endif
                DontDestroyOnLoad(go);
            }

            var newInstance = go.AddComponent<T>();
#if PCSOFT_SINGLETON_LOGGING
            Debug.Log("[Singleton] Initialize type " + typeof(T).FullName + "...");
#endif
            newInstance.OnInitializeSingleton();

            return newInstance;
        }

        #region Builtin Methods

        protected virtual void OnDestroy()
        {
#if PCSOFT_SINGLETON_LOGGING
            Debug.Log("[Singleton] Instance of type " + typeof(T).FullName + " obsolete, application is quitting...");
#endif
            applicationIsQuitting = true;
        }

        #endregion

        protected virtual void OnInitializeSingleton()
        {
        }
    }

    internal static class SingletonCreator
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void CreateInstanceImmediately()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .WhereHasAttribute<Type, SingletonAttribute>();

            foreach (var type in types.Select(x => x.Item1))
            {
                if (!type.GetCustomAttribute<SingletonAttribute>(true).CreateImmediately)
                    return;

                type.GetProperty("Instance",
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty |
                    BindingFlags.FlattenHierarchy)!.GetValue(null);
            }
        }
    }
}