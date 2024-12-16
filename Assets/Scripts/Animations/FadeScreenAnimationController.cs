using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Animation
{
    [RequireComponent(typeof(Image))]
    public class FadeScreenAnimationController : MonoBehaviour
    {
        [SerializeField] private float _duration;

        private Image _fadeImage;
        private float _alphaValueForBarelyFadeAnimation;
        private float _alphaFullValue;
        private float _alphaNullValue;

        private void Awake()
        {
            _fadeImage = GetComponent<Image>();
            _alphaFullValue = 1f;
            _alphaNullValue = 0f;
            _alphaValueForBarelyFadeAnimation = 0.5f;
        }

        private void Start()
        {
            TurnOffFadeScreen();
        }

        public void StartBarelyFadeOutAnimation()
        {
            _fadeImage.DOFade(_alphaValueForBarelyFadeAnimation, _duration).SetEase(Ease.InQuad);
        }

        public void TurnOnFadeScreen()
        {
            _fadeImage.DOFade(_alphaFullValue, _duration).SetEase(Ease.InQuad);
        }

        public void TurnOffFadeScreen()
        {
            _fadeImage.DOFade(_alphaNullValue, _duration).SetEase(Ease.InQuad);
        }
    }
}