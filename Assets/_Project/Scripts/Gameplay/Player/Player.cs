using SirGames.Scripts.Gameplay.Attributes;
using UnityEngine;

namespace SirGames.Scripts.Gameplay.Player
{
    public class Player : MonoBehaviour, IPlayer, Damage, Health
    {
        public int HealthAmount { get; }
        public int CurrentHealth { get; }
        public int DamageAmount { get; }
    }
}