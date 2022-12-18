using Assets.CodeBase.Infrastructure.Services;
using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Infrastructure.Services.Input;

namespace Assets.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Main = "Main";

        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(IGameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

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
            _services.RegisterSingle(AddInputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssetProvider>(),
                _services.Single<IInputService>()));
        }

        private IInputService AddInputService() {
            InputService inputService = new InputService();
            inputService.Initialize();

            return inputService;
        }
    }
}
