using Assets.CodeBase.Infrastructure.Services.AssetProvider;
using Assets.CodeBase.Infrastructure.Services.Input;
using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Logic;
using Assets.CodeBase.Platforms;
using Assets.CodeBase.Tower;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const int LevelCount = 10;

        private readonly IGameStateMachine _stateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;

        public GameFactory(IGameStateMachine stateMachine, IAssetProvider assetProvider, IInputService inputService) {
            _stateMachine = stateMachine;
            _assetProvider = assetProvider;
            _inputService = inputService;
        }

        public GameObject CreateLevel() {
            GameObject towerObject = _assetProvider.Instantiate(AssetAddress.Tower, Vector3.zero);

            TowerRotator rotator = towerObject.GetComponent<TowerRotator>();
            rotator.Construct(_inputService);

            GameObject towerCylinderObject = _assetProvider.Instantiate(AssetAddress.TowerCylinder, towerObject.transform);

            TowerScaler scaler = towerCylinderObject.GetComponent<TowerScaler>();
            scaler.Construct(LevelCount);
            scaler.Initialize();

            BallSpawnPosition spawnPosition = SetSpawnPlatform(towerCylinderObject, scaler);
            SetPlatforms(towerCylinderObject, scaler);
            SetFinishPlatform(towerCylinderObject, scaler);

            GameObject ball = CreateBall(spawnPosition);

            return ball;
        }

        public void CreateEndText() =>
            _assetProvider.Instantiate(AssetAddress.EndText).GetComponent<EndText>().Construct(_stateMachine);

        private GameObject CreateBall(BallSpawnPosition spawnPosition) {
            GameObject ballObject = _assetProvider.Instantiate(AssetAddress.Ball);
            ballObject.transform.position = spawnPosition.SpawnPoint;
            return ballObject;
        }

        private BallSpawnPosition SetSpawnPlatform(GameObject towerCylinderObject, TowerScaler scaler) => 
            CreatePlatformOnLevel(AssetAddress.SpawnPlatform, towerCylinderObject.transform, scaler, LevelCount + 1)
                .GetComponent<BallSpawnPosition>();

        private void SetPlatforms(GameObject towerCylinderObject, TowerScaler scaler) {
            for (int i = 0; i < LevelCount; i++) {
                CreatePlatformOnLevel(AssetAddress.Platform, towerCylinderObject.transform, scaler, i + 1);
            }
        }

        private void SetFinishPlatform(GameObject towerCylinderObject, TowerScaler scaler) => 
            CreatePlatformOnLevel(AssetAddress.FinishPlatform, towerCylinderObject.transform, scaler, 0)
                .GetComponent<Finish>().Construct(this);

        private GameObject CreatePlatformOnLevel(string platformAddress, Transform parent, TowerScaler scaler, int level) {
            GameObject newPlatform = _assetProvider.Instantiate(platformAddress, parent);
            scaler.SetPlatformOnLevel(level, newPlatform);

            return newPlatform;
        }
    }
}
