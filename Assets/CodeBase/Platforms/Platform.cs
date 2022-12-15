using UnityEngine;

namespace Assets.CodeBase.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _bounceForce;
        [SerializeField] private float _bounceRadius;
        [SerializeField] private PlatformSegment[] _segmentsToBreak;

        public void Break() {
            foreach(PlatformSegment segment in _segmentsToBreak)
                segment.Bounce(_bounceForce, transform.position, _bounceRadius);
        }
    }
}