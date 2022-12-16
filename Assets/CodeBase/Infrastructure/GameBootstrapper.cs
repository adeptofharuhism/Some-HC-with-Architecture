using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake() {
            _game = new Game(this);

            DontDestroyOnLoad(this);
        }
    }
}