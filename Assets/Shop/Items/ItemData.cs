using System;
using UnityEngine.UI;

[Serializable]
public class ShopCatalogData
{
    public Cosmetic[] items;
}

public class ShopUiData
{
    public Cosmetic cosmetic;
    public Button button;

    public ShopUiData(Cosmetic cosmetic, Button button)
    {
        this.cosmetic = cosmetic;
        this.button = button;
    }
}