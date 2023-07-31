using UnityEngine;

namespace Utils.ZenjectInstantiateUtil
{
    public interface IInstantiateSpawner
    {
        T Instantiate<T>();
        T Instantiate<T>(Object prefab, Transform parent = null);
    }
}