using System;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils
{
    public static class UnityDispatcher
    {
        public static void RunLater(Action action)
        {
            var controller = UnityDispatcherController.Singleton;
            if (controller == null)
                throw new InvalidOperationException("No dispatcher found in scene!");

            controller.RunLater(action);
        }

        public static void RunLater(uint framesToWait, Action action)
        {
            var controller = UnityDispatcherController.Singleton;
            if (controller == null)
                throw new InvalidOperationException("No dispatcher found in scene!");

            controller.RunLater(framesToWait, action);
        }

        public static void RunLater(float secondsToWait, Action action)
        {
            var controller = UnityDispatcherController.Singleton;
            if (controller == null)
                throw new InvalidOperationException("No dispatcher found in scene!");

            controller.RunLater(secondsToWait, action);
        }
    }
}