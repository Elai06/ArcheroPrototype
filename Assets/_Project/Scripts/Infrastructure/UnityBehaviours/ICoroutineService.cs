using System.Collections;
using UnityEngine;

namespace Infrastructure.UnityBehaviours
{
    public interface ICoroutineService
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopCoroutine(Coroutine coroutine);
    }
}