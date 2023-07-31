using UnityEngine;
using Zenject;

namespace Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = FILE, menuName = MENU)]
    public class GameStaticData : ScriptableObjectInstaller
    {
        private const string CATEGORY = "StaticData";
        private const string TITLE = "Game";
        private const string FILE = TITLE + CATEGORY;
        private const string MENU = "SirGames" + "/" + CATEGORY + "/" + TITLE;
        
        public override void InstallBindings()
        {
            Container.Bind<GameStaticData>().FromInstance(this).AsSingle();
        }
    }
}