using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HS
{
    public class UiButton : MonoBehaviour
    {

        [SerializeField] private GameObject _backpackUi;
        [SerializeField] private GameObject _shopUi;
        [SerializeField] private GameObject _sellUi;
        private bool _shopUiActive = false;
        private bool _backpackUiActive = false;
        private bool _sellUiActive = false;

        public void Backpack()
        {
            if (!(_sellUiActive || _shopUiActive))
            {
                _backpackUi.gameObject.SetActive(true);
                _backpackUiActive = true;
            }
        }

        public void Shop()
        {
            if (!(_sellUiActive || _backpackUiActive))
            {
                _shopUi.gameObject.SetActive(true);
                _shopUiActive = true;
            }
        }

        public void Sell()
        {
            if (!(_shopUiActive || _backpackUiActive))
            {
                _sellUi.gameObject.SetActive(true);
                _sellUiActive = true;
            }
        }

        public void BackpackClose()
        {
            _backpackUi.gameObject.SetActive(false);
            _backpackUiActive = false;
        }

        public void SellClose()
        {
            _sellUi.gameObject .SetActive(false);
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