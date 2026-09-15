using System;
using UnityEngine.UI;

public interface IPurchaseStrategy
{
    int GetPrice();
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public int price;
    public string type;

    public IPurchaseStrategy strategy;

    public void Buy(ShopManager manager)
    {
        manager.PurchaseItem(this);
    }
}