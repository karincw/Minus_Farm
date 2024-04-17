using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class SellFruit : MonoBehaviour
    {
        private int _currentPrice, _price, _maxCount, _currentCount;
        private TextMeshProUGUI _countText;
        private TextMeshProUGUI _priceText;
        private Slider _priceSlider;
        private CropInven _cropInven;

        private void Awake()
        {
            _priceSlider = transform.Find("Slider").GetComponent<Slider>();
            _priceText = transform.Find("Price").GetComponent<TextMeshProUGUI>();
            _countText = transform.Find("Count").GetComponent<TextMeshProUGUI>();
        }

        public void On_CountAndPriceChange()
        {
            _currentCount = Mathf.RoundToInt(_maxCount * _priceSlider.value);
            _currentPrice = _currentCount * _price;
            _priceText.text = _currentPrice.ToString();
            _countText.text = $"{_currentCount} / {_maxCount}";
        }

        public void Set_CountAndPrice(CropInven cropInven)
        {
            _cropInven = cropInven;
            _price = cropInven._currentPrice;
            _maxCount = cropInven._fruitCount;
            _priceText.text = _currentPrice.ToString();
            _countText.text = $"{_currentCount} / {_maxCount}";
        }

        public void Sell_Fruit()
        {
            GameObject.Find("Right").GetComponent<TopBarRightUi>().AddCredit(_currentPrice);
            _cropInven._fruitCount -= _currentCount;
            _cropInven.CountChange();
            _priceSlider.value = 0f;
        }
    }
}