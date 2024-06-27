using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button _restartButton;
        [Space(10)]
        [SerializeField] private DifferenceList _list;
        [SerializeField] private Timer _timer;
        [SerializeField] private TMP_Text _timerText;

        private float _seconds = 60;

        public event Action _onRestarted;

        private void Awake() => _restartButton.onClick.AddListener(RestartLevel);

        private void Start() => _timerText.text = $"Time to Fail: {_timer.TimerToEnd}";

        private void Update()
        {            
            _timerText.text = $"Time to Fail: {((_timer.TimerToEnd - 30) / _seconds):f0} : {(_timer.TimerToEnd % _seconds):f2}";                

            if (_list.DifferenceCount <= 0 || _timer.TimerToEnd <= 0) 
                _panel.gameObject.SetActive(true);
        }

        private void RestartLevel()
        {
            _onRestarted.Invoke();
            _panel.gameObject.SetActive(false);
        }
    }
}