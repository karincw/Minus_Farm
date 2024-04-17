using CW;
using HS;
using TMPro;
using UnityEngine;

public class SellFruit : MonoBehaviour
{
    private int _price, _count;
    private TextMeshProUGUI _countText;
    private TextMeshProUGUI _priceText;

    private void Start()
    {
        _priceText.text = transform.Find("Price").GetComponent<TextMeshProUGUI>().text = _price.ToString();
        _countText.text = transform.Find("Count").GetComponent<TextMeshProUGUI>().text = $"{1} / {_count}";
    }

    public void Set_CountAndPrice(int price, int count)
    {
        _price = price;
        _count = count;
    }
}
