using UnityEngine;

namespace Infrastructure.Windows.MVVM.SubView
{
    public abstract class SubView<TData> : MonoBehaviour
    {
        public abstract void Initialize(TData data);
    }
}