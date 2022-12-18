using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        bool IsTouched { get; }
        Vector2 TouchDelta { get; }

        void Disable();
        void Enable();
        void Initialize();
    }
}