using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure.Bootstrap
{
    public class GameRunner : MonoBehaviour
    {
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
            if(bootstrapper == null)
                SceneManager.LoadScene(0);
        }
    }
}