using System;
using System.Collections;
using Infrastructure.UnityBehaviours;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineService _coroutineService;

        public SceneLoader(ICoroutineService coroutineService) => 
            _coroutineService = coroutineService;

        public void Load(string name, Action onLoaded = null) =>
            _coroutineService.StartCoroutine(LoadScene(name, onLoaded));
    
        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
      
            var waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;
      
            onLoaded?.Invoke();
        }
    }
}