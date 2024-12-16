using Game.Model;
using Game.UI;
using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CardView), typeof(Raycaster))]
    public class CardHolder : MonoBehaviour
    {
        public event Action<CardHolder> OnCardClicked;

        private CardView _cardView;
        private Raycaster _raycaster;
        private Card _card;

        public int CardIdentifier => _card.Identifier;
        public string CardData => _card.Data;
        public CardView CardView => _cardView;

        private void Awake()
        {
            _cardView = GetComponent<CardView>();
            _raycaster = GetComponent<Raycaster>();
        }

        private void OnEnable() => _raycaster.Clicked += HandleClick;

        private void OnDisable() => _raycaster.Clicked -= HandleClick;

        public void SetCard(Card card)
        {
            _card = card;
            _cardView.DisplayCard(card);
        }

        private void HandleClick() => OnCardClicked?.Invoke(this);
    }
}