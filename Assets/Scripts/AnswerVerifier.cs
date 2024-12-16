using Game.Animation;
using Game.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class AnswerVerifier : MonoBehaviour
    {
        public event Action RightAnswerClicked;

        [SerializeField] private CardClicker _cardClicker;
        [SerializeField] private AnswerGenerator _answerGenerator;
        [SerializeField] private CardAnimationController _cardAnimationController;
        [SerializeField] private Particler _particler;
        [SerializeField] private float _delayAfterRightCardChoice;

        private int _rightCardIdentifier;
        private WaitForSeconds _rightCardChoiceDelay;

        private void Awake()
        {
            _rightCardChoiceDelay = new WaitForSeconds(_delayAfterRightCardChoice);
        }

        private void OnEnable()
        {
            _cardClicker.OnCardClicked += OnCardClicked;
        }

        private void OnDisable()
        {
            _cardClicker.OnCardClicked -= OnCardClicked;
        }

        private void OnCardClicked(CardHolder card)
        {
            bool result = VerifyCard(card.CardIdentifier);

            if (result == true)
            {
                _cardAnimationController.PlayRightCardAnimation(card.CardView);
                _particler.PlayRightCardEffect(card.transform);
                StartCoroutine(WaitAfterChooseRightCard());
            }
            else
            {
                _cardAnimationController.PlayWrongCardAnimation(card.CardView);
            }
        }

        private bool VerifyCard(int cardIdentifier)
        {
            _rightCardIdentifier = _answerGenerator.RightCardIdentifier;

            if (cardIdentifier == _rightCardIdentifier)
                return true;
            else
                return false;
        }

        private IEnumerator WaitAfterChooseRightCard()
        {
            yield return _rightCardChoiceDelay;

            RightAnswerClicked?.Invoke();
        }
    }
}