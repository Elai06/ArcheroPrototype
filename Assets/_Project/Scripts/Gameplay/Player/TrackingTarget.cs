using UnityEngine;

namespace _Project.Scripts.Gameplay.Player
{
    public class TrackingTarget : MonoBehaviour
    {
        public void LookOnTarget(Transform target)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}