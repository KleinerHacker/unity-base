using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components
{
    [Singleton(Instance = SingletonInstance.RequiresNewInstance, Scope = SingletonScope.Application, CreationTime = SingletonCreationTime.Loading)]
    internal sealed class HelpBehavior : SingletonBehavior<HelpBehavior>
    {
    }
}