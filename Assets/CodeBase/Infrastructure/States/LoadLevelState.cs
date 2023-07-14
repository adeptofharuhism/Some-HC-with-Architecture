using Assets.CodeBase.Ball;
using Assets.CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Logic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;

            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) {
            _loadingCurtain.Show();

            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        private void OnLoaded() {
            InitLevel();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitLevel() {
            GameObject ball = _gameFactory.CreateLevel();
            Camera.main.GetComponent<BallObserver>().Initialize(ball.transform);
        }
    }
}
