using Game.Model;
using Game.UI;
using UnityEngine;

namespace Game
{
    public class LevelActivator : MonoBehaviour
    {
        [SerializeField] private GridDrawer _gridDrawer;
        [SerializeField] private AnswerGenerator _answerGenerator;
        [SerializeField] private CardClicker _cardClicker;
        [SerializeField] private CardSpawner _cardSpawner;
        [SerializeField] private FirstBounceAnimationController _firstBounceAnimationController;
        [SerializeField] private FirstAnimationTaskTextController _firstAnimationTaskTextController;

        private Card[] _cards;

        public void Activate(Level level)
        {
            int cardsCount = level.RowsCount * level.ColumnsCount;
            _cards = _cardSpawner.TakeRandomCards(level.LevelCards, cardsCount);
            _gridDrawer.CreateGrid(level.ColumnsCount, level.RowsCount, _cards);
            _cardClicker.FillCards(_gridDrawer.GetCards());
            _answerGenerator.GenerateAnswer(_cards);
            _firstBounceAnimationController.BounceCards(_gridDrawer.GetCards());
            _firstAnimationTaskTextController.StartFadeAnimation();
        }
    }
}