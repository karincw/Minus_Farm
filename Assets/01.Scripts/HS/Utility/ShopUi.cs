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
        [SerializeField] private TopBarRightUi _topBarRightUi;
        [SerializeField] private List<CardSO> _cardSO = new List<CardSO>();
        [SerializeField] private List<Image> _image = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> _price = new List<TextMeshProUGUI>();
        private List<CardSO> _seed = new List<CardSO>();

        private void Awake()
        {
            SeedChange();
        }

        public void SeedChange()
        {
            List<CardSO> _changeSeed = _cardSO.ToList();

            for (int i = 0; i < 6; i++)
            {
                int index = Random.Range(0, _changeSeed.Count);
                _image[i].sprite = _changeSeed[index].sprite;
                _price[i].text = $"{_changeSeed[index].price}G";

                _seed.Add(_changeSeed[index]);
                _changeSeed.RemoveAt(index);
            }
        }

        public void BuyFruit(int num)
        {
            if (_topBarRightUi._credit >= _seed[num].price)
            {
                CardManager.Instance.AddCard(_seed[num]);
                _topBarRightUi.ChangeCredit(-_seed[num].price);
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
    }
}