using Game.Model;
using Game.UI;
using Game.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Game 
{
    public class AnswerGenerator : MonoBehaviour
    {
        [SerializeField] private TaskView _taskView;

        private string _task;
        private Card _rightCard;
        private List<Card> _answers;

        public int RightCardIdentifier => _rightCard.Identifier;

        private void Awake()
        {
            _answers = new List<Card>();
        }

        public void GenerateAnswer(Card[] cards)
        {
            do
            {
                _rightCard = cards[UserUtils.GetRandomNumber(0, cards.Length - 1)];
            } while (_answers.Contains(_rightCard) == true);

            _answers.Add(_rightCard);

            _task = $"Find {_rightCard.Data}";

            _taskView.DisplayTask(_task);
        }
    }
}