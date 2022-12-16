using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtainPrefab;

        private Game _game;

        private void Awake() {
            _game = new Game(this, Instantiate(_curtainPrefab));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}