using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog : MonoBehaviour
{
    public Item[] shopItems;
    public TextAsset catalogJson;
    public ShopUi ui;

    void Awake()
    {
        GetCatalogItems();
    }

    public void GetCatalogItems()
    {
        ShopCatalogData data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text); //reads JSON data

        shopItems = data.items;

        ui.FillShopUi();
    }
}
