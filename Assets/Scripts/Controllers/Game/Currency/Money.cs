using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    public event Action<int> OnMoneyValueChangedEvent;

    public int MoneyValue { get; private set; }

    public void Add(int money)
    {
        MoneyValue += money;

        OnMoneyValueChangedEvent?.Invoke(MoneyValue);
    }

    public void Spend(int money)
    {
        MoneyValue -= money;
        
        OnMoneyValueChangedEvent?.Invoke(MoneyValue);
    }
}
