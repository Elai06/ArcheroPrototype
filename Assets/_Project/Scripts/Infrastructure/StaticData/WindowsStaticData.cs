using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "WindowsStaticData", menuName = "Configs/WindowsStaticData")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowData> WindowsData = new();
    }
}