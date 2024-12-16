using UnityEngine;

public class FirstAnimationTaskTextController : MonoBehaviour
{
    [SerializeField] private TaskTextAnimationController _taskTextAnimationController;

    private bool _isFirstLevel;

    private void Awake()
    {
        _isFirstLevel = true;
    }

    public void StartFadeAnimation()
    {
        if (_isFirstLevel)
        {
            _taskTextAnimationController.StartFadeInAnimation();
            _isFirstLevel = false;
        }
    }
}