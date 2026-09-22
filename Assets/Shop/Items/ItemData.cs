using System;
using UnityEngine.UI;

[Serializable]
public class CosmeticData {
    public int id;
    public string type;
    public string name;
    public int price;
}

[Serializable]
public class ShopCatalogData {
    public CosmeticData[] items;
}