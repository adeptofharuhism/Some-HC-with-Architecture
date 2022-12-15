using Assets.CodeBase.Ball;
using UnityEngine;

namespace Assets.CodeBase.Platforms
{
    public class SpawnPlatform : Platform
    {
        [SerializeField] private BallObject _ball;
        [SerializeField] private Transform _spawnPoint;

        private void Awake() {
            Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
        }
    }
}