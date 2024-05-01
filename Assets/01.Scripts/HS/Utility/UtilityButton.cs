using UnityEngine;
using UnityEngine.UI;

namespace HS
{
    public class UtilityButton : MonoBehaviour
    {
        [SerializeField] private GameObject backpackUi;
        [SerializeField] private GameObject shopUi;
        [SerializeField] private GameObject sellUi;
        private SellFruit _sellFruit;
        private Image _fruitImageUi;
        private Sprite _fruitImage;
        private SpriteRenderer _spriteRenderer;
        private bool _shopUiActive;
        private bool _backpackUiActive;
        private bool _sellUiActive;

        private void Awake()
        {
            _fruitImageUi = sellUi.transform.Find("Image").GetComponent<Image>();
            _sellFruit = sellUi.GetComponent<SellFruit>();
            _spriteRenderer = GameObject.Find("DragObject").GetComponent<SpriteRenderer>();
        }

        public void BackpackOpen()
        {
            if (!(_sellUiActive || _shopUiActive))
            {
                backpackUi.gameObject.SetActive(true);
                _backpackUiActive = true;
            }
        }

        public void ShopOpen()
        {
            if (!(_sellUiActive || _backpackUiActive))
            {
                shopUi.gameObject.SetActive(true);
                _shopUiActive = true;
            }
        }

        public void SellOpen(CropInven cropInven)
        {
            if (cropInven._fruitCount != 0)
            {
                if (!(_shopUiActive || _backpackUiActive))
                {
                    sellUi.gameObject.SetActive(true);
                    _sellFruit.priceSlider.value = 0;
                    _sellUiActive = true;

                    _fruitImage = _spriteRenderer.sprite;

                    _fruitImageUi.sprite = _fruitImage;
                    _sellFruit.Set_CountAndPrice(cropInven);
                }
            }
        }

        public void BackpackClose()
        {
            backpackUi.gameObject.SetActive(false);
            _backpackUiActive = false;
        }

        public void SellClose()
        {
            sellUi.gameObject.SetActive(false);
            _sellUiActive = false;
        }

        public void ShopClose()
        {
            shopUi.gameObject.SetActive(false);
            _shopUiActive = false;
        }

        public void ShopChange()
        {
            if (shopUi.transform.Find("SeedPanel").gameObject.activeSelf)
            {
                shopUi.transform.Find("SeedPanel").gameObject.SetActive(false);
                shopUi.transform.Find("Real_EstatePanel").gameObject.SetActive(true);
            }
            else if (shopUi.transform.Find("Real_EstatePanel").gameObject.activeSelf)
            {
                shopUi.transform.Find("Real_EstatePanel").gameObject.SetActive(false);
                shopUi.transform.Find("SeedPanel").gameObject.SetActive(true);
            }
        }
    }
}