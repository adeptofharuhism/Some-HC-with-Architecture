using UnityEngine;

namespace Assets.CodeBase.Platforms
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformSegment : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Bounce(float force, Vector3 center, float radius) {
            if (_rigidbody == null)
                return;

            _rigidbody.isKinematic = false;
            _rigidbody.AddExplosionForce(force, center, radius);
        }
    }
}