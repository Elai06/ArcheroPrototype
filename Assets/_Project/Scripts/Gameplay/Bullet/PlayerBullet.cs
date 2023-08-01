using _Project.Scripts.Gameplay.Enemies;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Bullet
{
    public class PlayerBullet : Bullet
    {
        public override void OnCollisionEnter(Collision col)
        {
            base.OnCollisionEnter(col);

            var target = col.gameObject.GetComponent<Enemy>();
            target?.GetDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}