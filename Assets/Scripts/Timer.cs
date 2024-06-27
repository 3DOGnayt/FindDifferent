using UnityEngine;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Restart _restart;
        [Space(10)]
        [SerializeField] private float _timerToEnd;

        public float TimerToEnd => _timerToEnd;

        private void OnEnable() => _restart._onRestarted += UpdateTimer;

        private void OnDisable() => _restart._onRestarted -= UpdateTimer;

        private void Update()
        {
            if (_timerToEnd > 0)
                _timerToEnd -= Time.deltaTime;
        }

        private void UpdateTimer() => _timerToEnd = 120;
    }
}
