using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TaskTextAnimationController : MonoBehaviour
{
    [SerializeField] private float _durarion;

    private TextMeshProUGUI _taskText;

    public void StartFadeInAnimation()
    {
        _taskText.DOColor(Color.black, _durarion).SetEase(Ease.InQuad);
    }
}
