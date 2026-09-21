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
        var factory = new CosmeticFactory();

        foreach (CosmeticData item in data.items) {
            var cosmetic = factory.CreateCosmetic(item);

            shopCosmetics.Add(cosmetic);
        }

        ui.FillShopUi(shopCosmetics);
    }
}
