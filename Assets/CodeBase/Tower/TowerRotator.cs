using UnityEngine;

namespace Assets.CodeBase.Tower
{
    [RequireComponent(typeof(Rigidbody))]
    public class TowerRotator : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;

        private Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved) {
                    float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                    RotateOn(torque);
                }
            }

            if (Input.GetKey(KeyCode.A)) {
                RotateOn(-Time.deltaTime * _rotateSpeed);
            }

            if (Input.GetKey(KeyCode.D)) {
                RotateOn(Time.deltaTime * _rotateSpeed);
            }
        }

        private void RotateOn(float amount) {
            _rigidbody.AddTorque(Vector3.up * amount);
        }
    }
}