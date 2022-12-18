using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        void CreateEndText();
        GameObject CreateLevel();
    }
}
