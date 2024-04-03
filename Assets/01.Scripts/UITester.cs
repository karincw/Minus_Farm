using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITester : MonoBehaviour
{
    [SerializeField] private Image _shopPanel;
    [SerializeField] private Image _sellPanel;

    public void OpenShopPanel()
    {
        _shopPanel.gameObject.SetActive(true);
    }
    public void CloseShopPanel()
    {
        _shopPanel.gameObject.SetActive(false);
    }

    public void OpenSellPanel()
    {
        _sellPanel.gameObject.SetActive(true);
    }
    public void CloseSellPanel()
    {
        _sellPanel.gameObject.SetActive(false);
    }

}
