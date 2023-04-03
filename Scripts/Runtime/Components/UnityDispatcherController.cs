using System;
using System.Collections;
using System.Collections.Generic;
using UnityBase.Runtime.@base.Scripts.Runtime.Components.Singleton;
using UnityBase.Runtime.@base.Scripts.Runtime.Components.Singleton.Attributes;
using UnityEngine;

namespace UnityBase.Runtime.@base.Scripts.Runtime.Components
{
    [Singleton(Scope = SingletonScope.Application, Instance = SingletonInstance.RequiresNewInstance, CreationTime = SingletonCreationTime.Loading, ObjectName = "Dispatcher")]
    internal sealed class UnityDispatcherController : SingletonBehavior<UnityDispatcherController>
    {
        private readonly IList<Action> _runList = new List<Action>();

        public void RunLater(Action action)
        {
            AddAction(action, _runList);
        }

        public void RunLater(uint framesToWait, Action action)
        {
            AddAction(() => StartCoroutine(Wait()), _runList);

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
            AddAction(() => StartCoroutine(Wait()), _runList);

            IEnumerator Wait()
            {
                yield return new WaitForSecondsRealtime(secondsToWait);
                action();
            }
        }

        #region Builtin Methods

        private void LateUpdate()
        {
            RunActions(_runList);
        }

        #endregion

        private void AddAction(Action action, IList<Action> actions)
        {
            lock (actions)
            {
                actions.Add(action);
            }
        }

        private void RunActions(IList<Action> actions)
        {
            lock (actions)
            {
                foreach (var action in actions)
                {
                    action();
                }

                actions.Clear();
            }
        }
    }
}