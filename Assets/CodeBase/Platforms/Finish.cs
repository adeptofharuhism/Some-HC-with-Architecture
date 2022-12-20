using Assets.CodeBase.Ball;
using Assets.CodeBase.Infrastructure.Services.Factory;
using Assets.CodeBase.Infrastructure.Services.PersistentProgress;
using System;
using UnityEngine;

namespace Assets.CodeBase.Platforms
{
    public class Finish: MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private IPersistentProgress _progress;
        
        private bool _triggered = false;

        public void Construct(IGameFactory gameFactory, IPersistentProgress progress) {
            _gameFactory = gameFactory;
            _progress = progress;
        }

        private void OnCollisionEnter(Collision collision) {
            if (_triggered)
                return;

            if (!collision.gameObject.TryGetComponent(out BallJumper ball))
                return;

            _triggered = true;
            SaveLevel();
            _gameFactory.CreateEndText();
        }

        private void SaveLevel() {
            _progress.Progress.AddLevel();
            _progress.SaveProgress();
        }
    }
}