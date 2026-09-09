using UnityEngine;
using System;

public interface IPurchaseStrategy
{
    void Purchase(Item item, ShopManager manager);
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
        strategy.Purchase(this, manager);
    }
}

[Serializable]
public class ShopCatalogData
{
    public Item[] items;
}