using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Logic;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        public GameStateMachine StateMachine => _stateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain) {
            _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}