using _Project.Scripts.Gameplay.Bullet;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Configs.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        public int Health;
        public int MovementSpeed;
        public float DetectedRadius;
        public PlayerBullet Bullet;
    }
}