using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace HS
{
    public class TopBarMiddleUi : MonoBehaviour
    {
        private float _currentTime;
        private bool _isMorning = true;
        [SerializeField] private float _passesTime;
        [SerializeField] private int day, month;

        public UnityEvent OnDayChangeEvent;
        public UnityEvent OnDaynightChangeEvent;

        private TextMeshProUGUI _dayNightTxt;
        private TextMeshProUGUI _dateTime;

        private void Awake()
        {
            _dayNightTxt = transform.Find("Day&NightTxt").GetComponent<TextMeshProUGUI>();
            _dateTime = transform.Find("DateTxt").GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _passesTime)
            {
                if (_isMorning)
                {
                    _dayNightTxt.text = "저녁";
                    _isMorning = false;
                    OnDaynightChangeEvent.Invoke();
                }
                else
                {
                    _dayNightTxt.text = "아침";
                    _isMorning = true;

                    day++;
                    if (day == 30)
                    {
                        month++;
                        day = 0;
                    }
                    OnDaynightChangeEvent.Invoke();
                    OnDayChangeEvent.Invoke();
                    _dateTime.text = $"{month.ToString("D2")} {day.ToString("D2")}";
                }
                _currentTime = 0;
            }
        }
    }
}