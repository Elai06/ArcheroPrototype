using MVVMLibrary.Enums;
using UnityEngine;

namespace Infrastructure.Windows
{
    [CreateAssetMenu(fileName = "Window", menuName = "Data/Window")]
    public class WindowStaticData : ScriptableObject
    {
        public WindowType Type;
        public Layer Layer;
        public GameObject Window;
    }
}