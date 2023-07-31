namespace Infrastructure.Windows
{
    public abstract class PayloadWindow<TPayload> : Window
    {
        public abstract void OnOpen(TPayload payload);
    }
}