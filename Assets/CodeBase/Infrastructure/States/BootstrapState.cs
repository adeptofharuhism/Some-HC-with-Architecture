namespace Assets.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Main = "Main";

        private IGameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine stateMachine, SceneLoader sceneLoader) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;

            RegisterServices();
        }

        public void Enter() {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit() {

        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(Main);

        private void RegisterServices() {
            
        }
    }
}
