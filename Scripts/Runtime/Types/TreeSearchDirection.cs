using System;

namespace UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Types
{
    [Flags]
    public enum TreeSearchDirection
    {
        None = 0x00,
        Children = 0x01,
        Current = 0x02,
        Parent = 0x04,
        All = Children | Current | Parent,
    }
}