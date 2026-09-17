using System;
using UnityEngine.UI;

[Serializable]
public class ShopCatalogData {
    public CosmeticData[] items;
}

public class ShopUiData {
    public Cosmetic cosmetic;
    public Button button;

    public ShopUiData(Cosmetic cosmetic, Button button) {
        this.cosmetic = cosmetic;
        this.button = button;
    }
}

[Serializable]
public class CosmeticData {
    public int id;
    public string type;
    public string name;
    public int price;
}