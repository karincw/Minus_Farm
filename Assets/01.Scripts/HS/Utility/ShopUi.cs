using CW;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class ShopUi : MonoBehaviour
    {
        [SerializeField] private TopBarRightUi topBarRightUi;
        [SerializeField] private List<CardSO> _cardSO = new List<CardSO>();
        [SerializeField] private List<Image> image = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> priceText = new List<TextMeshProUGUI>();

        private void Awake()
        {
            SeedChange();
        }

        public void SeedChange()
        {
            for (int i = 0; i < 100; ++i)
            {
                int first = Random.Range(0, _cardSO.Count);
                int second = Random.Range(0, _cardSO.Count);

                (_cardSO[first], _cardSO[second]) = (_cardSO[second], _cardSO[first]);
            }
            
            for (int i = 0; i < 6; i++)
            {
                image[i].sprite = _cardSO[i].sprite;
                priceText[i].text = $"{_cardSO[i].price}G";
            }
        }

        public void BuyFruit(int num)
        {
            if (topBarRightUi.credit >= _cardSO[num].price)
            {
                CardManager.Instance.AddCard(_cardSO[num]);
                topBarRightUi.ChangeCredit(-_cardSO[num].price);
            }
            else
            {
                transform.Find("Warning").gameObject.SetActive(true);
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