using CW;
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
        private Slider _slider;
        private Image _fillImage;
        private Image _image;
        [SerializeField] private float passesTime;
        [SerializeField] private int startDay, startMonth;
        [SerializeField] private Sprite[] sprite;

        public UnityEvent OnDayChangeEvent;
        public UnityEvent OnDaynightChangeEvent;

        private void Awake()
        {
            _slider = transform.Find("Slider").GetComponent<Slider>();
            _fillImage = _slider.transform.Find("FillArea").Find("Fill").GetComponent<Image>();
            _dayNightTxt = transform.Find("Day&NightTxt").GetComponent<TextMeshProUGUI>();
            _dateTime = transform.Find("DateTxt").GetComponent<TextMeshProUGUI>();
            _image = transform.Find("Day&NightImg").GetComponent<Image>();
        }

        private void Start()
        {
            OnDayChangeEvent?.Invoke();
            OnDaynightChangeEvent?.Invoke();

            FindObjectOfType<StandCard>().Stand();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= passesTime)
            {
                if (_isMorning)
                {
                    _fillImage.color = new Color(0.26f, 0.13f, 0.52f);
                    _dayNightTxt.text = "저녁";
                    _isMorning = false;
                    OnDaynightChangeEvent?.Invoke();
                    _image.sprite = sprite[0];
                }
                else
                {
                    _fillImage.color = new Color(1, 0.58f, 0);
                    _dayNightTxt.text = "아침";
                    _isMorning = true;

                    startDay++;
                    if (startDay == 30)
                    {
                        startMonth++;
                        startDay = 0;
                    }
                    OnDaynightChangeEvent?.Invoke();
                    OnDayChangeEvent?.Invoke();
                    _image.sprite = sprite[1];
                    _dateTime.text = $"{startMonth.ToString("D2")} {startDay.ToString("D2")}";
                }
                _currentTime = 0;
            }
            _slider.value = _currentTime / passesTime;
        }
    }
}