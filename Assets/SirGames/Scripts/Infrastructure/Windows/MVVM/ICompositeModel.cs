using System;
using System.Collections.Generic;

namespace Infrastructure.Windows.MVVM
{
    public interface ICompositeModel<out TModel>
    {
        IEnumerable<TModel> Models { get; }
    }

    public interface IExtendedCompositeModel<out TModel> : ICompositeModel<TModel>
    {
        event Action<TModel> ModelAdded;
        event Action<TModel> ModelRemoved;
    }
}