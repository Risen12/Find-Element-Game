using Game.Animation;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
    public class RestartGameScreen : MonoBehaviour 
    {
        [SerializeField] private RestartGameButton _restartGameButton;
        [SerializeField] private FadeScreenAnimationController _fadeScreenAnimationController;
        [SerializeField] private TextMeshProUGUI _restartText;

        private float _delay;
        private WaitForSeconds _waitBeforeRestartGame;

        private void Awake()
        {
            _delay = 1.1f;
            _waitBeforeRestartGame = new WaitForSeconds(_delay);
        }

        private void OnEnable()
        {
            _restartGameButton.RestartButtonClicked += OnRestartGameButtonClicked;
        }

        private void OnDisable()
        {
            _restartGameButton.RestartButtonClicked -= OnRestartGameButtonClicked;
        }

        private IEnumerator RestartGameWithDelay()
        {
            _fadeScreenAnimationController.TurnOnFadeScreen();
            _restartGameButton.gameObject.SetActive(false);
            _restartText.gameObject.SetActive(false);

            yield return _waitBeforeRestartGame;

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        private void OnRestartGameButtonClicked() => StartCoroutine(RestartGameWithDelay());
    }
}