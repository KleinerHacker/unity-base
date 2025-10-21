using UnityEngine.AI;

namespace UnityExtension.Runtime.Projects.unity_extension.Scripts.Runtime.Utils.Extensions
{
    public static class NavMeshAgentExtensions
    {
        public static bool IsArrived(this NavMeshAgent agent)
        {
            return !agent.pathPending && 
                   agent.remainingDistance <= agent.stoppingDistance && 
                   (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
        }
    }
}