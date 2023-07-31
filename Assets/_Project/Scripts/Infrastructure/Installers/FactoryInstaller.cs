using Zenject;

namespace Infrastructure.Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
        }

        private void BindFactories()
        {
        }
    }
}