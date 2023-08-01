using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Gameplay.UI.Pause
{
    public class PauseView : MonoBehaviour
    {
        private void OnEnable()
        {
            Pause(true);
        }

        private void OnDisable()
        {
            Pause(false);
        }
        
        private void Pause(bool isPause)
        {
            Time.timeScale = isPause ? 0 : 1;
        }
    }
}