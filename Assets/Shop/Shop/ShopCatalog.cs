using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog : MonoBehaviour
{
    public Item[] shopItems;
    public TextAsset catalogJson;
    public ShopUi ui;
    public ShopManager manager;

    void Awake()
    {
        GetCatalogItems();
    }

    public void GetCatalogItems()
    {
        ShopCatalogData data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text); //reads JSON data

        shopItems = data.items;

        foreach (var item in shopItems)
        {
            item.Initialize(manager);

            if (item.id == 3)
            {
                item.ChangeState(new SaleState(item, manager, 20));
            }
        }

        ui.FillShopUi(shopItems);
    }
}
