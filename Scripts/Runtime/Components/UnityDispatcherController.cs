using System;
using System.Collections;
using System.Collections.Generic;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components
{
    [Singleton(ObjectName = "Dispatcher")]
    internal sealed class UnityDispatcherController : SingletonBehavior<UnityDispatcherController>
    {
        private readonly IList<Action> _runList = new List<Action>();

        public void RunLater(Action action)
        {
            AddAction(action);
        }

        public void RunLater(uint framesToWait, Action action)
        {
            AddAction(() => StartCoroutine(Wait()));

            IEnumerator Wait()
            {
                for (var i = 0; i < framesToWait; i++)
                {
                    yield return null;
                }

                action();
            }
        }

        public void RunLater(float secondsToWait, Action action)
        {
            AddAction(() => StartCoroutine(Wait()));

            IEnumerator Wait()
            {
                yield return new WaitForSecondsRealtime(secondsToWait);
                action();
            }
        }

        #region Builtin Methods

        private void LateUpdate()
        {
            RunActions();
        }

        #endregion

        private void AddAction(Action action)
        {
            lock (this)
            {
                _runList.Add(action);
            }
        }

        private void RunActions()
        {
            lock (this)
            {
                foreach (var action in _runList)
                {
                    action();
                }

                _runList.Clear();
            }
        }
    }
}