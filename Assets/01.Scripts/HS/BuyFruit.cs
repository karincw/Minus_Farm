using CW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFruit : MonoBehaviour
{
    [SerializeField] private CardSO _cardSO;

    public void Buy()
    {
        CardManager.Instance.AddCard(_cardSO);
    }
}
