using UnityEngine;

namespace Utils.ZenjectInstantiateUtil
{
    public class GameObjectDestroyer : IGameObjectDestroyer
    {
        public void DestroyGameObject(GameObject destroy)
        {
            Object.Destroy(destroy);
        }
    }
}