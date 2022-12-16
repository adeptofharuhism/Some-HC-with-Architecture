using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateLevel();
    }
}
