using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.Services.PersistentProgress;

namespace Assets.CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const int InitialLevel = 5;
        private const string Main = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgress _progress;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgress progress) {
            _stateMachine = stateMachine;
            _progress = progress;
        }

        public void Enter() {
            LoadProgressOrInitNew();

            _stateMachine.Enter<LoadLevelState, string>(Main);
        }

        public void Exit() {

        }

        private void LoadProgressOrInitNew() {
            _progress.Progress = _progress.LoadProgress() ?? InitNewProgress();
        }

        private PlayerProgress InitNewProgress() =>
            new PlayerProgress(initialLevel: InitialLevel);
    }
}
