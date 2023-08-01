using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private LayerMask _bulletTargetLayer;

        protected int _damage;

        public virtual void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.layer != _bulletTargetLayer)
            {
                Destroy(gameObject);
                return;
            }
        }

        public void Shot(Transform targetPosition,float force, int damage)
        {
            _damage = damage;
            
            Vector3 playerDirection = (targetPosition.position - transform.position).normalized;
            _rb.velocity = playerDirection * force;
        }
    }
}