using SirGames.Scripts.Infrastructure.StateMachine;
using SirGames.Scripts.Infrastructure.StateMachine.Sates;
using UnityEngine;
using Zenject;

namespace SirGames.Scripts.Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake() => DontDestroyOnLoad(gameObject);

        private void Start()
        {
            _stateMachine?.Enter<BootstrapState>();
        }
    }
}