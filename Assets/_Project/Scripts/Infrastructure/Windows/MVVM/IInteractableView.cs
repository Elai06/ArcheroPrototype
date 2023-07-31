using System;

namespace Infrastructure.Windows.MVVM
{
    public interface IInteractableView
    {
        event Action Clicked;
    }
}