using Game;
using Game.Animation;
using System.Collections.Generic;
using UnityEngine;

public class FirstBounceAnimationController : MonoBehaviour
{
    [SerializeField] private CardAnimationController _cardAnimationController;

    private bool _isFirstLaunch;

    private void Awake()
    {
        _isFirstLaunch = true;
    }

    public void BounceCards(List<CardHolder> cards)
    {
        if (_isFirstLaunch)
        {
            foreach (CardHolder card in cards)
                _cardAnimationController.PlayBounceAnimation(card.CardView);

            _isFirstLaunch = false;
        }
    }
}