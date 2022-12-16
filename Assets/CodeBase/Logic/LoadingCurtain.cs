using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private float _alphaChangePerFrame = 0.03f;
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake() {
            DontDestroyOnLoad(this);
        }

        public void Show() {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide() =>
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn() {
            while (_canvasGroup.alpha > 0) {
                _canvasGroup.alpha -= _alphaChangePerFrame;
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}