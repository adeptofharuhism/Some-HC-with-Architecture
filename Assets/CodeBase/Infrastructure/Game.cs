using Assets.CodeBase.Infrastructure.States;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        public Game(ICoroutineRunner coroutineRunner) {
            _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}