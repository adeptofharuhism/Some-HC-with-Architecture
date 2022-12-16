using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Platforms
{
    public class BallSpawnPosition : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        public Vector3 SpawnPoint => _spawnPoint.position;
    }
}