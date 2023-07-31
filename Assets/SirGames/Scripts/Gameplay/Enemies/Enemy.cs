using SirGames.Scripts.Gameplay.Attributes;
using UnityEngine;

namespace SirGames.Scripts.Gameplay.Enemies
{
    public abstract class Enemy: MonoBehaviour, Damage, Health
    {
        public int DamageAmount { get; }
        public int HealthAmount { get; }
        public int CurrentHealth { get; }
    }
}