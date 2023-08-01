using System;
using SirGames.Scripts.Gameplay.Enemies;

namespace _Project.Scripts.Gameplay.Configs.Enemy
{
    [Serializable]
    public class EnemyConfigData
    {
        public EnemyType Type;

        public Enemies.Enemy Enemy;
        public Bullet.EnemyBullet Bullet;
        
        public int DamageAmount;
        public int HealthAmount;
        public float FireRate;
        public float MovementSpeed;
        public float RadiusAttack;
        public float ForceShot;
    }
}