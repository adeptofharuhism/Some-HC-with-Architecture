using Assets.CodeBase.Platforms;
using UnityEngine;

namespace Assets.CodeBase.Tower
{
    public class TowerBuilder : MonoBehaviour
    {
        private const float StartAndFinishAdditionalScale = 0.5f;

        [SerializeField] private int _levelCount;
        [SerializeField] private float _additionalBeamScale;
        [SerializeField] private GameObject _beamPrefab;
        [SerializeField] private SpawnPlatform _spawnPlatformPrefab;
        [SerializeField] private FinishPlatform _finishPlatformPrefab;
        [SerializeField] private Platform[] _platformPrefabs;

        public float BeamScaleY => _levelCount / 2f + StartAndFinishAdditionalScale + _additionalBeamScale / 2f;

        private void Awake() {
            Build();
        }

        private void Build() {
            GameObject beam = Instantiate(_beamPrefab, transform);
            beam.transform.localScale = new Vector3(
                beam.transform.localScale.x,
                BeamScaleY,
                beam.transform.localScale.z);

            Vector3 spawnPosition = beam.transform.position;
            spawnPosition.y += beam.transform.localScale.y - _additionalBeamScale;

            SpawnPlatformAndDecrementPosition(_spawnPlatformPrefab, ref spawnPosition, beam.transform);

            for (int i = 0; i < _levelCount; i++) {
                SpawnPlatformAndDecrementPosition(
                    _platformPrefabs[Random.Range(0, _platformPrefabs.Length)],
                    ref spawnPosition,
                    beam.transform);
            }

            SpawnPlatformAndDecrementPosition(_finishPlatformPrefab, ref spawnPosition, beam.transform);
        }

        private void SpawnPlatformAndDecrementPosition(Platform platform, ref Vector3 spawnPosition, Transform parent) {
            GameObject newPlatform = 
                Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent).gameObject;

            newPlatform.transform.localScale = new Vector3(
                newPlatform.transform.localScale.x,
                newPlatform.transform.localScale.y / BeamScaleY,
                newPlatform.transform.localScale.z);
            spawnPosition.y--;
        }
    }
}