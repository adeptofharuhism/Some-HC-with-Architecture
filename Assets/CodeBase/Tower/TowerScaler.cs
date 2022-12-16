using UnityEngine;

namespace Assets.CodeBase.Tower
{
    public class TowerScaler : MonoBehaviour
    {
        [SerializeField] private float _additionalScale = 5f;

        private int _levelAmount;

        public void Construct(int levelAmount) {
            _levelAmount = levelAmount;
        }

        public void Initialize() {
            ChangeTowerScale();
        }

        public void SetPlatformOnLevel(int level, GameObject platform) {
            platform.transform.position = new Vector3(
                transform.position.x,
                transform.position.y - transform.localScale.y + level,
                transform.position.z);

            platform.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            platform.transform.localScale = new Vector3(
                platform.transform.localScale.x,
                platform.transform.localScale.y / transform.localScale.y,
                platform.transform.localScale.z);
        }

        private void ChangeTowerScale() {
            transform.localScale = new Vector3(
                transform.localScale.x,
                _levelAmount / 2f + 0.5f + _additionalScale,
                transform.localScale.z);
        }
    }
}