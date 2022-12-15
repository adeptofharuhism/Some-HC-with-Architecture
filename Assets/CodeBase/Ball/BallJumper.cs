using Assets.CodeBase.Platforms;
using UnityEngine;

namespace Assets.CodeBase.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallJumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;

        private Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.TryGetComponent(out PlatformSegment segment)) {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
}

