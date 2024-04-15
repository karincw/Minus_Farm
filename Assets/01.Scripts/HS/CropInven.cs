using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class CropInven : MonoBehaviour
    {
        [SerializeField] private int _fruitCount = 0;
        private int _minPrice = 5000;
        private int _maxPrice = 10000;
        private int _currentPrice = 0;
        private int _beforePrice;
        private TMP_Text _priceText;
        private TMP_Text _countText;
        private Image _priceImage;
        [SerializeField]
        private Sprite[] _priceSprite;

        private void Awake()
        {
            _priceText = transform.Find("Price").GetComponent<TMP_Text>();
            _priceImage = transform.Find("PriceImage").GetComponent<Image>();
            _countText = transform.Find("Count").GetComponent<TMP_Text>();
            _priceImage.sprite = _priceSprite[0];
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
