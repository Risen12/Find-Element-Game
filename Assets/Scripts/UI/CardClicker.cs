using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class CardClicker : MonoBehaviour
    {
        public event Action<CardHolder> OnCardClicked;

        private List<CardHolder> _cards;

        private void OnDisable()
        {
            UnsubscribeForCardsClickedEvents();
        }

        public void FillCards(List<CardHolder> cards)
        { 
            _cards = cards;
            SubscribeForCardsClickedEvents();
        }

        public void MakeCardsUnclickable()
        { 
            foreach (CardHolder card in _cards) 
            {
                card.CardView.ChangeClickablekState(false);
            }
        }

        private void SubscribeForCardsClickedEvents()
        {
            foreach (CardHolder card in _cards)
                card.OnCardClicked += HandleCardClick;
        }

        private void UnsubscribeForCardsClickedEvents() 
        {
            foreach (CardHolder card in _cards)
                card.OnCardClicked -= HandleCardClick;
        }

        private void HandleCardClick(CardHolder card) => OnCardClicked?.Invoke(card);
    }
}