using Assets.CodeBase.Infrastructure.States;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Logic
{
    public class EndText : MonoBehaviour
    {
        [Header("Animating Time")]
        [SerializeField] private float _appearanceTime = 1f;
        [SerializeField] private float _disappearanceTime = 1f;
        [Header("Requirements")]
        [SerializeField] private Image _background;
        [SerializeField] private TMP_Text _gayText;
        
        private IGameStateMachine _stateMachine;
        private Tween _tween;

        public void Construct(IGameStateMachine stateMachine) {
            _stateMachine = stateMachine;
        }

        private void Start() {
            ShowUp();
        }

        private void ShowUp() {
            _tween = _gayText.DOColor(Color.white, _appearanceTime);
            _tween.onComplete += Hide;
        }

        private void Hide() {
            _tween?.Kill();
            _tween = _background.DOColor(Color.black, _disappearanceTime);
            _tween.onComplete += Reload;
        }

        private void Reload() {
            _tween.Kill();
            _stateMachine.Enter<LoadLevelState, string>(Constants.SceneNames.Main);
        }
    }
}