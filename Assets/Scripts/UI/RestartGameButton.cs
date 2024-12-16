using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartGameButton : MonoBehaviour
    {
        public event Action RestartButtonClicked;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable() => _button.onClick.AddListener(RestartGame);

        private void OnDisable() => _button.onClick.RemoveListener(RestartGame);

        private void RestartGame() => RestartButtonClicked?.Invoke();
    }
}