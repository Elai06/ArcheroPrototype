using Zenject;

namespace Infrastructure.Installers
{
    public class ModelsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindModels();
        }

        private void BindModels()
        {

        }
    }
}