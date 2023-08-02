using System;
using _Project.Scripts.Gameplay.UI.Inventory.Guns;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Configs.Guns
{
    [Serializable]
    public class GunsConfigData
    {
        public GunsType Type;
        public int Damage;
        public float FireRate;
        public float ForceShot;
        public Sprite Sprite;
        public Gun Gun;
    }
}