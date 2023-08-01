using _Project.Scripts.Infrastructure.StateMachine.States;
using SirGames.Scripts.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Bootstrap
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

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                _stateMachine.Enter<ExitState>();
            }
        }

        private void OnApplicationQuit()
        {
            _stateMachine.Enter<ExitState>();
        }
    }
}