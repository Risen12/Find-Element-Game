using Game.UI;
using System;
using UnityEngine;

namespace Game
{
    public class Raycaster : MonoBehaviour
    {
        public event Action Clicked;

        private void OnMouseDown()
        {
            OnClick();
        }

        private void OnClick()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider.gameObject.TryGetComponent(out CardView cardView))
            {
                Clicked?.Invoke();
            }
        }
    }
}