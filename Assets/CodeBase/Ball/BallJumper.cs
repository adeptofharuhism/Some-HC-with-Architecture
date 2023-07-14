using Assets.CodeBase.Platforms;
using UnityEngine;

namespace Assets.CodeBase.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallJumper : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpCooldown = 0.2f;

        private Rigidbody _rigidbody;

        private float _lastJumpTime;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.TryGetComponent(out PlatformSegment segment)) {
                if (CooldownPassed()) {
                    SetCooldownTimeStart();
                    Jump();
                }
            }
        }

        private void SetCooldownTimeStart() =>
            _lastJumpTime = Time.time;

        private void Jump() {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private bool CooldownPassed() =>
            _lastJumpTime + _jumpCooldown < Time.time;
    }
}

