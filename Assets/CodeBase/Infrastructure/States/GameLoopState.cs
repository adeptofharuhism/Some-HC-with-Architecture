namespace Assets.CodeBase.Infrastructure.States
{
    internal class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void Enter() {

        }

        public void Exit() {

        }
    }
}