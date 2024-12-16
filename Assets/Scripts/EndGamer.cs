using Game.Animation;
using Game.UI;
using UnityEngine;

namespace Game
{
    public class EndGamer : MonoBehaviour
    {
        [SerializeField] private FadeScreenAnimationController _fadeScreenAnimationController;
        [SerializeField] private RestartGameScreen _restartGameScreen;
        [SerializeField] private CardClicker _cardClicker;
        [SerializeField] private Particler _particler;

        public void HandleEndGame()
        {
            _fadeScreenAnimationController.StartBarelyFadeOutAnimation();
            _restartGameScreen.gameObject.SetActive(true);
            _particler.StopLastEffect();
            _cardClicker.MakeCardsUnclickable();
        }
    }
}