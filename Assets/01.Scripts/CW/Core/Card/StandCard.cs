using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CW
{

    public class StandCard : MonoBehaviour
    {
        [SerializeField] Card[] _standImages;
        [SerializeField] TextMeshProUGUI _descriptionText;
        [SerializeField] List<CardSO> _currentCards = new List<CardSO>();
        private CardInven _cardInven;

        private void Awake()
        {
            _cardInven = FindObjectOfType<CardInven>();
            _currentCards.Clear();
        }

        [ContextMenu("Stand")]
        public void Stand()
        {
            if (_currentCards.Count > 0)
            {
                _currentCards.AddRange(_cardInven.GetCards());
                return;
            }

            _currentCards.AddRange(_cardInven.GetCards());

            int curCardSize = _currentCards.Count - 1;
            for (int i = 0; i < 6; i++)
            {
                int cur = curCardSize - i;
                CardSO nextCard = _currentCards[cur];
                _standImages[i].CurrentCard = nextCard;
                _currentCards.RemoveAt(cur);
            }
        }

        [ContextMenu("Update")]
        public void UpdateCard()
        {
            for (int i = 0; i < 6; i++)
            {
                int nextIdx = i + 1;
                CardSO nextCard = null;
                if (nextIdx < _standImages.Length)
                {
                    if (_standImages[nextIdx] != null)
                    {
                        nextCard = _standImages[nextIdx].CurrentCard;
                    }
                    else if (nextCard == null && _currentCards.Count > 0)
                    {
                        int cur = _currentCards.Count - 1;
                        nextCard = _currentCards[cur];
                        _currentCards.RemoveAt(cur);
                    }

                    _standImages[i].CurrentCard = nextCard;
                }
                else
                {
                    if (nextCard == null && _currentCards.Count > 0)
                    {
                        int cur = _currentCards.Count - 1;
                        nextCard = _currentCards[cur];
                        _currentCards.RemoveAt(cur);
                    }

                    _standImages[i].CurrentCard = nextCard;
                }

            }

        }

    }

}