using Utils.ZenjectInstantiateUtil;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class InjectService
    {
        private static InjectService _instance;
        public static InjectService Instance => _instance ??= new InjectService();
        
        private ZenjectInstantiateSpawner _instantiateSpawner;

        public void SetInjectSpawner(ZenjectInstantiateSpawner instantiateSpawner)
        {
            _instantiateSpawner = instantiateSpawner;
        }

        public void Inject(object obj)
        {
            _instantiateSpawner.Inject(obj);
        }
    }
}