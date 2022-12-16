using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameRunner: MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _gameBootstrapperPrefab;

        private void Awake() {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();

            if (bootstrapper == null)
                Instantiate(_gameBootstrapperPrefab);

            Destroy(gameObject);
        }
    }
}