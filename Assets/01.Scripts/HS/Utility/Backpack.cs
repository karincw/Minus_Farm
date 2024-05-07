using System.Linq;
using CW;
using UnityEngine;

namespace HS
{
    public class Backpack : MonoBehaviour
    {
        private CardInven _cardInven;
        private CardSO _beforeCardSo;
        private GameObject _layout;
        [SerializeField] private InvenSlot slotPre;

        private void Awake()
        {
            _layout = transform.Find("Lay").gameObject;
            _cardInven = GameObject.Find("CardInventory").GetComponent<CardInven>();
        }

        public void SetInven()
        {
            if (gameObject.activeSelf)
            {
                int c = _layout.transform.childCount;
                for (int i = 0; i < c; i++)
                {
                    Destroy(_layout.transform.GetChild(i).gameObject);
                }

                _cardInven.inventory = _cardInven.inventory.OrderBy((a) => a.name).ToList();
                _beforeCardSo = _cardInven.inventory[0];
                int count = 0;
                InvenSlot inven;
                foreach (var card in _cardInven.inventory)
                {
                    if (card == _beforeCardSo)
                    {
                        count++;
                    }
                    else
                    {
                        inven = Instantiate(slotPre, _layout.transform);
                        inven.SetInvenSlot(count, _beforeCardSo.curName, _beforeCardSo.sprite);

                        count = 1;
                    }

                    _beforeCardSo = card;
                }

                inven = Instantiate(slotPre, _layout.transform);
                inven.SetInvenSlot(count, _beforeCardSo.curName, _beforeCardSo.sprite);
            }
        }
    }
}