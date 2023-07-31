using System;

namespace Infrastructure.SceneManagement
{
    public interface ISceneLoader
    {
        void Load(string scene, Action onLoad);
    }
}