using UnityEngine;

namespace Utils.ZenjectInstantiateUtil
{
    public interface IGameObjectFactory
    {
        GameObject InstantiatePrefab(GameObject prefab, Transform parent = null);
        GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null);
    }
}