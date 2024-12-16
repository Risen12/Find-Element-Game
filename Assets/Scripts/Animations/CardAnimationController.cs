using UnityEngine;
using DG.Tweening;
using Game.UI;

namespace Game.Animation
{
    public class CardAnimationController : MonoBehaviour
    {
        [SerializeField] private Vector3 _bounceMaxSize;
        [SerializeField] private Vector3 _bounceMinSize;
        [SerializeField] private float _duration;
        [SerializeField] private float _moveDistance;
        [SerializeField] private float _delayAfterAnimation;

        private Vector3 _defaultSize;

        public void PlayBounceAnimation(CardView card)
        {
            Transform target = card.CardIconTransform;

            Sequence bounceSequence = DOTween.Sequence();
            _defaultSize = target.localScale;

            bounceSequence.Append(target.transform.DOScale(_bounceMaxSize, _duration).SetEase(Ease.OutBounce))
                          .Append(target.transform.DOScale(_bounceMinSize, _duration).SetEase(Ease.OutBounce))
                          .Append(target.transform.DOScale(_defaultSize, _duration).SetEase(Ease.OutBounce))
                          .AppendInterval(_delayAfterAnimation)
                          .OnComplete(() => HandleEndAnimation(card));

            bounceSequence.Play();
        }

        public void PlayWrongCardAnimation(CardView card)
        {
            card.ChangeClickablekState(false);
            PlayEaseInBounceAnimation(card);
        }

        public void PlayRightCardAnimation(CardView card)
        {
            card.ChangeClickablekState(false);
            PlayBounceAnimation(card);
        }

        private void PlayEaseInBounceAnimation(CardView card)
        {
            Transform target = card.CardIconTransform;

            Sequence bounceSequence = DOTween.Sequence();

            bounceSequence.Append(target.DOMoveX(target.position.x - _moveDistance, _duration).SetEase(Ease.InBounce))
                          .Append(target.DOMoveX(target.position.x + _moveDistance, _duration).SetEase(Ease.InBounce))
                          .Append(target.DOMoveX(target.position.x, _duration).SetEase(Ease.InBounce))
                          .AppendInterval(_delayAfterAnimation)
                          .OnComplete(() => HandleEndAnimation(card));

            bounceSequence.Play();
        }

        private void HandleEndAnimation(CardView cardView) => cardView.ChangeClickablekState(true);
    }
}