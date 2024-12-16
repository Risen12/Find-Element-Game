using Game.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridDrawer : MonoBehaviour
    {
        [SerializeField] private CardHolder _cardPrefab;
        [SerializeField] private float _spacing;

        private List<CardHolder> _cards;

        private void Awake()
        {
            _cards = new List<CardHolder>();
        }

        public void CreateGrid(int columnsCount, int rowsCount, Card[] cards)
        {
            Clear();

            float divider = 2f;
            Vector3 gridSize = new Vector3(columnsCount * _spacing, rowsCount * _spacing, 0);
            Vector3 startPosition = new Vector3(-gridSize.x / divider + _spacing / divider + transform.position.x,
                                         -gridSize.y / divider + _spacing / divider + transform.position.y, 0);
            int cardIndex = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < columnsCount; column++)
                {
                    Vector3 position = startPosition + new Vector3(column * _spacing, row * _spacing, 0);
                    CardHolder cardHolder = Instantiate(_cardPrefab, position, Quaternion.identity);
                    cardHolder.transform.SetParent(transform);
                    cardHolder.SetCard(cards[cardIndex]);
                    _cards.Add(cardHolder);
                    cardIndex++;
                }
            }
        }

        public List<CardHolder> GetCards() 
        {
            List<CardHolder> cards = new List<CardHolder>();

            foreach (CardHolder card in _cards)
                cards.Add(card);

            return cards;
        }

        private void Clear()
        { 
            foreach(CardHolder card in _cards)
                Destroy(card.gameObject);

            _cards.Clear();
        }
    }
}