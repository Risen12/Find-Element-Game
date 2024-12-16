using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Animation
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TaskTextAnimationController : MonoBehaviour
    {
        [SerializeField] private float _durarion;

        private TextMeshProUGUI _taskText;

        private void Awake()
        {
            _taskText = GetComponent<TextMeshProUGUI>();
        }

        public void StartFadeInAnimation()
        {
            _taskText.DOColor(Color.black, _durarion).SetEase(Ease.InQuad);
        }
    }
}