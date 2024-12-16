using TMPro;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TaskView : MonoBehaviour
    {
        private TextMeshProUGUI _taskText;

        private void Awake()
        {
            _taskText = GetComponent<TextMeshProUGUI>();
        }

        public void DisplayTask(string task)
        {
            _taskText.text = task;
        }
    }
}