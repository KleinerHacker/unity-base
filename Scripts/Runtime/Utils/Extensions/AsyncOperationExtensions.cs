using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions
{
    public static class AsyncOperationExtensions
    {
        public static bool IsReady(this AsyncOperation asyncOperation) => asyncOperation.progress >= 0.9f;

        public static float CalculateProgress(this IEnumerable<AsyncOperation> list) => list.Sum(x => x.progress) / list.Count();

        public static bool IsReady(this IEnumerable<AsyncOperation> list) => list.All(x => x.IsReady());

        public static bool IsDone(this IEnumerable<AsyncOperation> list) => list.All(x => x.isDone);
    }
}