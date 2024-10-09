using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components.Singleton.Attributes;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Components
{
    [Singleton(ObjectName = "Help Behavior")]
    public sealed class HelpBehavior : SingletonBehavior<HelpBehavior>
    {
    }
}