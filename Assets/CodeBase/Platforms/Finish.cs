using Assets.CodeBase.Ball;
using Assets.CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace Assets.CodeBase.Platforms
{
    public class Finish: MonoBehaviour
    {
        private IGameFactory _gameFactory;

        private bool _triggered = false;

        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void OnCollisionEnter(Collision collision) {
            if (_triggered)
                return;

            if (!collision.gameObject.TryGetComponent(out BallJumper ball))
                return;

            _triggered = true;
            _gameFactory.CreateEndText();
        }
    }
}