using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class UiButton : MonoBehaviour
    {
        [SerializeField] private GameObject _backpackUi;
        [SerializeField] private GameObject _shopUi;
        [SerializeField] private GameObject _sellUi;
        private SellFruit _sellFruit;
        private Image _fruitImageUi;
        private Sprite _fruitImage;
        private bool _shopUiActive = false;
        private bool _backpackUiActive = false;
        private bool _sellUiActive = false;

        private void Awake()
        {
            _fruitImageUi = _sellUi.transform.Find("Image").GetComponent<Image>();
            _sellFruit = _sellUi.GetComponent<SellFruit>();
        }

        public void BackpackOpen()
        {
            if (!(_sellUiActive || _shopUiActive))
            {
                _backpackUi.gameObject.SetActive(true);
                _backpackUiActive = true;
            }
        }

        public void ShopOpen()
        {
            if (!(_sellUiActive || _backpackUiActive))
            {
                _shopUi.gameObject.SetActive(true);
                _shopUiActive = true;
            }
        }

        public void SellOpen(int _count, int _price)
        {
            if (!(_shopUiActive || _backpackUiActive))
            {
                _sellUi.gameObject.SetActive(true);
                _sellUiActive = true;

                _fruitImage = GameObject.Find("DragObject").GetComponent<SpriteRenderer>().sprite;

                _fruitImageUi.sprite = _fruitImage;
                _sellFruit.Set_CountAndPrice(_price, _count);
            }
        }

        public void BackpackClose()
        {
            _backpackUi.gameObject.SetActive(false);
            _backpackUiActive = false;
        }

        public void SellClose()
        {
            _sellUi.gameObject.SetActive(false);
            _sellUiActive = false;
        }

        public void ShopClose()
        {
            _shopUi.gameObject.SetActive(false);
            _shopUiActive = false;
        }

        public void ShopChange()
        {
            if (_shopUi.transform.Find("SeedPanel").gameObject.activeSelf == true)
            {
                _shopUi.transform.Find("SeedPanel").gameObject.SetActive(false);
                _shopUi.transform.Find("Real_EstatePanel").gameObject.SetActive(true);
            }
            else if (_shopUi.transform.Find("Real_EstatePanel").gameObject.activeSelf == true)
            {
                _shopUi.transform.Find("Real_EstatePanel").gameObject.SetActive(false);
                _shopUi.transform.Find("SeedPanel").gameObject.SetActive(true);
            }
        }
    }
}