using Assets.CodeBase.Platforms;
using UnityEngine;

namespace Assets.CodeBase.Ball
{
    public class BallPlatformChecker : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent(out PlatformSegment segment)) {
                other.GetComponentInParent<Platform>().Break();
            }
        }
    }
}