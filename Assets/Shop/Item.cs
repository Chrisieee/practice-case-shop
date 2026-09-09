using UnityEngine;
using System;

[Serializable]
public class Item
{
    public int id;
    public string name;
    public int price;
    public string type;
}

[Serializable]
public class ShopCatalogData
{
    public Item[] items;
}