using System;
using CW;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace HS
{
    public class CropInven : MonoBehaviour
    {
        [SerializeField] public int _fruitCount = 0;
        [SerializeField] private int _minPrice;
        [SerializeField] private int _maxPrice;
        [SerializeField] public int _currentPrice = 0;
        private int _beforePrice;
        private TextMeshProUGUI _priceText;
        private TextMeshProUGUI _countText;
        private Drag _drag;
        private Image _priceImage;
        [SerializeField]
        private Sprite[] _priceSprite;

        private TopBarMiddleUi _topMiddleUI;
        
        private void Awake()
        {
            _priceText = transform.Find("Price").GetComponent<TextMeshProUGUI>();
            _priceImage = transform.Find("PriceImage").GetComponent<Image>();
            _countText = transform.Find("Count").GetComponent<TextMeshProUGUI>();
            //_drag = transform.Find("CropImage").GetComponent<Drag>();
            _priceImage.sprite = _priceSprite[0];
            _countText.text = _fruitCount.ToString();
            _priceText.text = _currentPrice.ToString();
            _topMiddleUI = GameObject.Find("Middle").GetComponent<TopBarMiddleUi>();
            RandomPrice();
            
            _topMiddleUI.OnDayChangeEvent.AddListener(RandomPrice);
        }

        private void Start()
        {
            //_minPrice = _drag.currentCard.sellMinPrice;
            //_maxPrice = _drag.currentCard.sellMaxPrice;
        }

        public void SetCount(int count)
        {
            _fruitCount = count;
            ChangeCount();
        }

        public void AddCount(int count)
        {
            _fruitCount += count;
            ChangeCount();
        }

        public int GetCount()
        {
            return _fruitCount;
        }

        public void ChangeCount()
        {
            _countText.text = _fruitCount.ToString();
        }

        public void RandomPrice()
        {
            _currentPrice = Random.Range(_minPrice, _maxPrice);
            if (_currentPrice > _beforePrice)
            {
                _priceImage.sprite = _priceSprite[2];
            }
            else if (_currentPrice < _beforePrice)
            {
                _priceImage.sprite = _priceSprite[1];
            }
            else
            {
                _priceImage.sprite = _priceSprite[0];
            }

            _priceText.text = _currentPrice.ToString();
            _beforePrice = _currentPrice;
        }
    }
}
