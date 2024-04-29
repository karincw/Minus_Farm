using CW;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<TextMeshProUGUI> price = new List<TextMeshProUGUI>();
        private readonly List<CardSO> _seed = new List<CardSO>();

        private void Awake()
        {
            SeedChange();
        }

        public void SeedChange()
        {
            List<CardSO> changeSeed = _cardSO.ToList();

            for (int i = 0; i < 6; i++)
            {
                int index = Random.Range(0, changeSeed.Count);
                image[i].sprite = changeSeed[index].sprite;
                price[i].text = $"{changeSeed[index].price}G";

                _seed.Add(changeSeed[index]);
                changeSeed.RemoveAt(index);
            }
        }

        public void BuyFruit(int num)
        {
            if (topBarRightUi.credit >= _seed[num].price)
            {
                CardManager.Instance.AddCard(_seed[num]);
                topBarRightUi.ChangeCredit(-_seed[num].price);
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