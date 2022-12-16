using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider: IService
    {
        GameObject Instantiate(string address);
        GameObject Instantiate(string address, Vector3 at);
        GameObject Instantiate(string address, Transform parent);
    }
}