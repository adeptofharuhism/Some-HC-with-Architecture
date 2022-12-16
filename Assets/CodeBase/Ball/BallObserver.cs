using UnityEngine;

namespace Assets.CodeBase.Ball
{
    public class BallObserver : MonoBehaviour
    {
        [SerializeField] private float _observingRange = 5;
        [SerializeField] private Vector3 _directionOffset;

        private Transform _ballTransform;
        private Vector3 _minimalBallPosition;

        public void Initialize(Transform ballTransform) {
            _ballTransform = ballTransform;
            _minimalBallPosition = _ballTransform.position;
        }

        private void Update() {
            if (_ballTransform == null)
                return;

            if (_ballTransform.position.y < _minimalBallPosition.y) {
                UpdateCameraPosition();
                _minimalBallPosition = _ballTransform.position;
            }
        }

        private void UpdateCameraPosition() {
            Vector3 towerPosition = Vector3.zero;
            towerPosition.y = _ballTransform.position.y;

            Vector3 newCameraPosition = _ballTransform.position;
            Vector3 direction = (towerPosition - _ballTransform.position).normalized + _directionOffset;

            newCameraPosition -= direction * _observingRange;

            transform.position = newCameraPosition;
            transform.LookAt(_ballTransform);
        }
    }
}