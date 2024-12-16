using UnityEngine;

namespace Game.Model
{
    [CreateAssetMenu(fileName = "Card", menuName = "Card/Create new card", order = 51)]
    public class Card : ScriptableObject
    {
        [SerializeField] private int _identifier;
        [SerializeField] private string _data;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Quaternion _spriteRotation;
        [SerializeField] private Vector3 _offsetPosition;

        public int Identifier => _identifier;
        public string Data => _data;
        public Sprite Sprite => _sprite;
        public Quaternion SpriteRotation => _spriteRotation;
        public Vector3 OffsetPosition => _offsetPosition;
    }
}