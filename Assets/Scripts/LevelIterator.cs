using Game.Model;
using UnityEngine;

namespace Game
{
    public class LevelIterator : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;
        [SerializeField] private LevelActivator _levelActivator;
        [SerializeField] private AnswerVerifier _answerVerifier;
        [SerializeField] private EndGamer _endGamer;

        private int _currentIndex;

        private void Awake()
        {
            _currentIndex = -1;
        }

        private void OnEnable()
        {
            _answerVerifier.RightAnswerClicked += Iterate;
        }

        private void OnDisable()
        {
            _answerVerifier.RightAnswerClicked -= Iterate;
        }

        private void Start()
        {
            Iterate();
        }

        private void Iterate()
        {
            if (_currentIndex == _levels.Length - 1)
            {
                _endGamer.HandleEndGame();
                return;
            }

            _currentIndex++;

            _levelActivator.Activate(_levels[_currentIndex]);
        }
    }
}