using UnityEngine;

namespace _Project.Scripts.Gameplay.Bullet
{
    public class EnemyBullet : Bullet
    {
        public override void OnCollisionEnter(Collision col)
        {
            base.OnCollisionEnter(col);

            var target = col.gameObject.GetComponent<Player.Player>();
            target?.GetDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}