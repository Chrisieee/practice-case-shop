using System;
using UnityEngine.UI;

[Serializable]
public class ShopCatalogData
{
    public Item[] items;
}

public class ShopUiData
{
    public Item item;
    public Button button;

    public ShopUiData(Item item, Button button)
    {
        this.item = item;
        this.button = button;
    }
}