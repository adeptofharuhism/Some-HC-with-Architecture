using Assets.CodeBase.Tower;
using UnityEngine;

namespace Assets.CodeBase.Ball
{
    public class BallTracking : MonoBehaviour
    {
        [SerializeField] private Vector3 _directionOffset;
        [SerializeField] private float _length;

        private BallObject _ball;
        private TowerCylinder _tower;
        private Vector3 _cameraPosition;
        private Vector3 _minimalBallPosition;

        private void Start() {
            _ball = FindObjectOfType<BallObject>();
            _tower = FindObjectOfType<TowerCylinder>();

            _cameraPosition = _ball.transform.position;
            _minimalBallPosition = _ball.transform.position;

            TrackBall();
        }

        private void Update() {
            if (_ball.transform.position.y < _minimalBallPosition.y) {
                TrackBall();
                _minimalBallPosition = _ball.transform.position;
            }
        }

        private void TrackBall() {
            Vector3 towerPosition = _tower.transform.position;
            towerPosition.y = _ball.transform.position.y;

            _cameraPosition = _ball.transform.position;
            Vector3 direction = (towerPosition - _ball.transform.position).normalized + _directionOffset;

            _cameraPosition -= direction * _length;

            transform.position = _cameraPosition;
            transform.LookAt(_ball.transform);
        }
    }
}