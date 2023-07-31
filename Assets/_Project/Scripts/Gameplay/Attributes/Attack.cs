using UnityEngine;

namespace SirGames.Scripts.Gameplay.Attributes
{
    public abstract class Attack : MonoBehaviour, Damage
    {
        public int DamageAmount { get; }

        public virtual void DoDamage(int damage)
        {
            
        }
    }
}