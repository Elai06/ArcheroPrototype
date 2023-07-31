using PathfinderNode;
using Zenject;

namespace Infrastructure.Installers
{
    public class NavigationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<INavigationService>()
                .To<NodePathfinder>()
                .AsSingle();
        }
    }
}