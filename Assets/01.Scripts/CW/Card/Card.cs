using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CW
{

    public class Card : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;

        private Image _currentImage;

        private CardSO _currentCard;
        public CardSO CurrentCard
        {
            get { return _currentCard; }
            set
            {
                _currentCard = value;

                if (_currentCard == null)
                {
                    _currentImage.sprite = null;
                    _currentImage.color = new Color(1, 1, 1, 0);
                    if (_descriptionText != null)
                        _descriptionText.text = "";
                    return;
                }

                _currentImage.color = new Color(1, 1, 1, 1);
                _currentImage.sprite = _currentCard.Sprite;

                if (UseDescription == true)
                {
                    _descriptionText.text = _currentCard.description;
                }
            }
        }

        private void Awake()
        {
            _currentImage = GetComponent<Image>();
        }

        public bool UseDescription = false;

    }

}