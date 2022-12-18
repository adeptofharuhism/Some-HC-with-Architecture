using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private Controls _controls;
        private bool _isTouched = false;

        public bool IsTouched => _isTouched;
        public Vector2 TouchDelta => _controls.Touchscreen.TouchDelta.ReadValue<Vector2>();

        public InputService() {
            _controls = new Controls();
        }

        public void Initialize() {
            InitializeForTouchscreen();
        }

        public void Enable() {
            _controls.Enable();
        }

        public void Disable() {
            _controls.Disable();
        }

        private void InitializeForTouchscreen() {
            _controls.Touchscreen.Touch.started += ctx => _isTouched = true;
            _controls.Touchscreen.Touch.canceled += ctx => _isTouched = false;
        }
    }
}
