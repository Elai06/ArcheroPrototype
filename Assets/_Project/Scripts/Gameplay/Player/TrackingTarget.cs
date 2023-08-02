using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{
    public class TrackingTarget : MonoBehaviour
    {
        public void LookOnTarget(Transform target)
        {
            if(target == null) return;
            
            Vector3 direction = target.position - transform.position;
           // direction.y = 0f;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}