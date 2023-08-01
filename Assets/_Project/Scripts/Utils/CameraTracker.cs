using System;
using UnityEngine;

namespace _Project.Scripts.Utils
{
    public class CameraTracker : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothSpeed = 0.2f;

        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - _target.position;
        }

        private void Update()
        {
            Vector3 desiredPosition = _target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}