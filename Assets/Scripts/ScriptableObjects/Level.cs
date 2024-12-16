using UnityEngine;

namespace Game.Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level/Create new level", order = 52)]
    public class Level : ScriptableObject
    {
        [SerializeField] private int _columnsCount;
        [SerializeField] private int _rowsCount;
        [SerializeField] private Card[] _levelCards;

        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;
        public Card[] LevelCards => _levelCards;
    }
}