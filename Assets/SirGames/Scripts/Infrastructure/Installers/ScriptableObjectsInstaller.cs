using MVVMLibrary;
using MVVMLibrary.Settings;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ScriptableObjectsInstaller : MonoInstaller
    {
        [SerializeField] private PunchAnimationSettings _punchAnimationSettings;
        public override void InstallBindings()
        {
           UIAnimations.SetPunchAnimationSettings(_punchAnimationSettings);
        }
    }
}