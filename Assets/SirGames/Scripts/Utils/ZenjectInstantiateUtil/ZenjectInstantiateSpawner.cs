using UnityEngine;
using Zenject;

namespace Utils.ZenjectInstantiateUtil
{
    public class ZenjectInstantiateSpawner : IInstantiateSpawner, IInjector, IGameObjectFactory
    {
        private readonly DiContainer _diContainer;

        public ZenjectInstantiateSpawner(DiContainer container)
        {
            _diContainer = container;
        }

        public T Instantiate<T>()
        {
            return _diContainer.Instantiate<T>();
        }
        
        public T Instantiate<T>(Object prefab, Transform parent = null)
        {
            return _diContainer.InstantiatePrefabForComponent<T>(prefab, parent);
        }

        public GameObject InstantiatePrefab(GameObject prefab, Transform parent = null)
        {
            return _diContainer.InstantiatePrefab(prefab, parent);
        }

        public GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _diContainer.InstantiatePrefab(prefab, position, rotation, parent);
        }

        public void Inject(object injectable)
        {
            _diContainer.Inject(injectable);
        }
    }
}