using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string address) =>
            GameObject.Instantiate(Resources.Load<GameObject>(address));

        public GameObject Instantiate(string address, Vector3 at) =>
            GameObject.Instantiate(Resources.Load<GameObject>(address), at, Quaternion.identity);

        public GameObject Instantiate(string address, Transform parent) =>
            GameObject.Instantiate(Resources.Load<GameObject>(address), parent);
    }
}
