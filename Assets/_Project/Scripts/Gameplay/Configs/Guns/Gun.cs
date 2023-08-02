using UnityEngine;

namespace _Project.Scripts.Gameplay.Configs.Guns
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _shotPosition;

        public Transform GetShotPosition()
        {
            return _shotPosition;
        }
    }
}