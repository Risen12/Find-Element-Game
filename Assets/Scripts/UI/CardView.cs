using Game.Model;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _cardIcon;

        private BoxCollider2D _collider;

        public Transform CardIconTransform => _cardIcon.transform;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        public void DisplayCard(Card card)
        {
            _cardIcon.sprite = card.Sprite;

            _cardIcon.transform.rotation = card.SpriteRotation;
            _cardIcon.transform.localPosition = card.OffsetPosition;
        }

        public void ChangeClickablekState(bool state)
        {
            if (state == true)
                _collider.enabled = true;
            else
                _collider.enabled = false;
        }
    }
}