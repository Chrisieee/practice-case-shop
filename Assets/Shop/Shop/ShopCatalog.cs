using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog : MonoBehaviour {
    private List<Cosmetic> shopCosmetics;
    [SerializeField] private TextAsset catalogJson;
    [SerializeField] private ShopUi ui;

    void Awake() {
        GetCatalogItems();
    }

    public void GetCatalogItems() {
        ShopCatalogData data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text);

        shopCosmetics = new List<Cosmetic>();

        foreach (CosmeticData item in data.items) {
            var factory = new CosmeticFactory();
            var cosmetic = factory.CreateCosmetic(item.type);

            cosmetic.id = item.id;
            cosmetic.name = item.name;
            cosmetic.price = item.price;

            shopCosmetics.Add(cosmetic);
        }

        ui.FillShopUi(shopCosmetics);
    }
}
