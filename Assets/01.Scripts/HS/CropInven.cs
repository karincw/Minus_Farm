using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class CropInven : MonoBehaviour
    {
        [SerializeField] public int _fruitCount = 0;
        [SerializeField] private int _minPrice = 5000;
        [SerializeField] private int _maxPrice = 10000;
        [SerializeField] public int _currentPrice = 0;
        private int _beforePrice;
        private TextMeshProUGUI _priceText;
        private TextMeshProUGUI _countText;
        private Image _priceImage;
        [SerializeField]
        private Sprite[] _priceSprite;

        private void Awake()
        {
            _priceText = transform.Find("Price").GetComponent<TextMeshProUGUI>();
            _priceImage = transform.Find("PriceImage").GetComponent<Image>();
            _countText = transform.Find("Count").GetComponent<TextMeshProUGUI>();
            _priceImage.sprite = _priceSprite[0];
            _countText.text = _fruitCount.ToString();
            _priceText.text = _currentPrice.ToString();
        }

        public void SetCount(int count)
        {
            _fruitCount = count;
            CountChange();
        }

        public void AddCount(int count)
        {
            _fruitCount += count;
            CountChange();
        }

        public int GetCount()
        {
            return _fruitCount;
        }

        public void CountChange()
        {
            _countText.text = _fruitCount.ToString();
        }

        public void Random_Price()
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
