using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        }

        [ContextMenu("Stand")]
        public void Stand()
        {
            _currentCards.Clear();
            _currentCards.AddRange(_cardInven.GetCards());
            _currentCards.Add(ScriptableObject.CreateInstance<CardSO>());

            int curCardSize = _currentCards.Count - 1;
            for (int i = 0; i < 6; i++)
            {
                int cur = curCardSize - i;
                CardSO nextCard = _currentCards[cur];
                _standImages[i].currentCard = nextCard;
                _standImages[i].visible = nextCard == null ? true : false;
                _currentCards.RemoveAt(cur);
            }

            UpdateCard();
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
                        nextCard = _standImages[nextIdx].currentCard;
                    }
                    else if (nextCard == null && _currentCards.Count > 0)
                    {
                        int cur = _currentCards.Count - 1;
                        nextCard = _currentCards[cur];
                        _currentCards.RemoveAt(cur);
                    }

                    _standImages[i].currentCard = nextCard;
                    _standImages[i].visible = nextCard == null ? true : false;
                }
                else
                {
                    if (nextCard == null && _currentCards.Count > 0)
                    {
                        int cur = _currentCards.Count - 1;
                        nextCard = _currentCards[cur];
                        _currentCards.RemoveAt(cur);
                    }

                    _standImages[i].currentCard = nextCard;
                    _standImages[i].visible = nextCard == null ? true : false;
                }
                if (i == 0 && _currentCards.Count > 0)
                {
                    _descriptionText.text = _currentCards[_currentCards.Count - 1].description;
                }

            }

        }

    }

}