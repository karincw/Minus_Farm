using CW;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HS
{
    public class ShopUi : MonoBehaviour
    {
        [SerializeField] private TopBarRightUi topBarRightUi;
        [SerializeField] private List<CardSO> _cropCardSO = new List<CardSO>();
        [SerializeField] private List<CardSO> _allCardSO = new List<CardSO>();
        [SerializeField] private List<CardSO> _sellCard = new List<CardSO>();
        [SerializeField] private List<Image> image = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> priceText = new List<TextMeshProUGUI>();

        private void Awake()
        {
            SeedChange();
        }

        public void SeedChange()
        {
            CardSuffle(_cropCardSO);
            CardSuffle(_allCardSO);
            
            for (int i = 0; i < 2; i++)
            {
                image[i].sprite = _cropCardSO[i].sprite;
                priceText[i].text = $"{_cropCardSO[i].price}G";
                _sellCard[i] = _cropCardSO[i];
            }

            for (int i = 0;  i < 2; i++)
            {
                if (_allCardSO[i] == _cropCardSO[0] || _allCardSO[i] == _cropCardSO[1]) 
                {
                    i--;
                    CardSuffle(_allCardSO);
                    continue;
                }
                image[i + 2].sprite = _allCardSO[i].sprite;
                priceText[i + 2].text = $"{_allCardSO[i].price}G";
                _sellCard[i + 2] = _allCardSO[i];
            }
        }

        private void CardSuffle(List<CardSO> _card)
        {
            for (int i = 0; i < 100; ++i)
            {
                int first = Random.Range(0, _card.Count);
                int second = Random.Range(0, _card.Count);

                (_card[first], _card[second]) = (_card[second], _card[first]);
            }
            
            
        }

        public void BuyFruit(int num)
        {
            if (topBarRightUi.credit >= _sellCard[num].price)
            {
                CardManager.Instance.AddCard(_sellCard[num]);
                topBarRightUi.ChangeCredit(-_sellCard[num].price);
            }
            else
            {
                OpenWarning();
            }
        }

        public void CloseWarning()
        {
            transform.Find("Warning").gameObject.SetActive(false);
        }

        public void OpenWarning()
        {
            transform.Find("Warning").gameObject.SetActive(true);
        }
    }
}