using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog : MonoBehaviour
{
    public Cosmetic[] shopCosmetics;
    public TextAsset catalogJson;
    public ShopUi ui;

    void Awake()
    {
        GetCatalogItems();
    }

    public void GetCatalogItems()
    {
        ShopCatalogData data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text); //reads JSON data

        shopCosmetics = data.items;

        ui.FillShopUi();
    }
}
