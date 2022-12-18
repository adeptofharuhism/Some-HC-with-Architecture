using Assets.CodeBase.Infrastructure.Services.Input;
using System;
using UnityEngine;

namespace Assets.CodeBase.Tower
{
    [RequireComponent(typeof(Rigidbody))]
    public class TowerRotator : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;

        private Rigidbody _rigidbody;

        private IInputService _inputService;

        public void Construct(IInputService inputService) {
            _inputService = inputService;
        }

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (_inputService.IsTouched)
                RotateOn(_inputService.TouchDelta.x);
        }

        private void RotateOn(float amount) {
            _rigidbody.AddTorque(Vector3.up * amount * _rotateSpeed);
        }
    }
}