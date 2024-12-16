using Game.Model;
using Game.Utils;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class CardSpawner : MonoBehaviour
    {
        public Card[] TakeRandomCards(Card[] cards, int count)
        {
            Card[] randomCards = new Card[count];

            for (int i = 0; i < randomCards.Length; i++)
            {
                Card nextCard;

                do
                {
                    nextCard = TakeRandomCard(cards);
                } while (randomCards.Contains(nextCard) == true);

                randomCards[i] = nextCard;
            }

            return randomCards;
        }

        private Card TakeRandomCard(Card[] cards)
        {
            return cards[UserUtils.GetRandomNumber(0, cards.Length - 1)];
        }
    }
}