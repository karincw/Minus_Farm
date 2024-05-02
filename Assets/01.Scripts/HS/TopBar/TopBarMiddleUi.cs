using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HS
{
    public class TopBarMiddleUi : MonoBehaviour
    {
        private float _currentTime;
        private bool _isMorning = true;
        private TextMeshProUGUI _dayNightTxt;
        private TextMeshProUGUI _dateTime;
        private Image _image;
        [SerializeField] private float passesTime;
        [SerializeField] private int day, month;
        [SerializeField] private Sprite []sprite;
        
        public UnityEvent OnDayChangeEvent;
        public UnityEvent OnDaynightChangeEvent;

        private void Awake()
        {
            _dayNightTxt = transform.Find("Day&NightTxt").GetComponent<TextMeshProUGUI>();
            _dateTime = transform.Find("DateTxt").GetComponent<TextMeshProUGUI>();
            _image = transform.Find("Day&NightImg").GetComponent<Image>();
        }

        private void Start()
        {
            OnDayChangeEvent?.Invoke();
            OnDaynightChangeEvent?.Invoke();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= passesTime)
            {
                if (_isMorning)
                {
                    _dayNightTxt.text = "저녁";
                    _isMorning = false;
                    OnDaynightChangeEvent.Invoke();
                    _image.sprite = sprite[0];
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
                    _image.sprite = sprite[1];
                    _dateTime.text = $"{month.ToString("D2")} {day.ToString("D2")}";
                }
                _currentTime = 0;
            }
        }
    }
}