using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class CropInven : MonoBehaviour
    {
        [SerializeField] private int _fruitCount = 0;
        [SerializeField] private int _minPrice = 5000;
        [SerializeField] private int _maxPrice = 10000;
        [SerializeField] private int _currentPrice = 0;
        private int _beforePrice;

        private TextMeshProUGUI _priceText;
        private TextMeshProUGUI _countText;
        private Image _priceImage;
        //[SerializeField] private Sprite[] _priceSprite;
        [SerializeField] private Sprite _upPriceSprite, _downPriceSprite, _samePriceSprite;

        private void Awake()
        {
            _priceText = transform.Find("Price").GetComponent<TextMeshProUGUI>();
            _countText = transform.Find("Count").GetComponent<TextMeshProUGUI>();
            _priceImage = transform.Find("PriceImage").GetComponent<Image>();
            _priceImage.sprite = _samePriceSprite;
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

        [ContextMenu("countChange")]
        public void CountChange()
        {
            _countText.text = _fruitCount.ToString();
        }

        [ContextMenu("random")]
        public void Random_Price()
        {
            _currentPrice = Random.Range(_minPrice, _maxPrice);
            if (_currentPrice > _beforePrice)
            {
                _priceImage.sprite = _upPriceSprite;
            }
            else if (_currentPrice < _beforePrice)
            {
                _priceImage.sprite = _downPriceSprite;
            }
            else
            {
                _priceImage.sprite = _samePriceSprite;
            }
            _priceText.text = _currentPrice.ToString();
            _beforePrice = _currentPrice;
            CountChange();
        }
    }
}
