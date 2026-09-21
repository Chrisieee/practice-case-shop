using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog : MonoBehaviour {
    private List<Cosmetic> shopCosmetics = new List<Cosmetic>();
    [SerializeField] private TextAsset catalogJson;
    [SerializeField] private ShopUi ui;

    void Awake() {
        GetCatalogItems();
    }

    public void GetCatalogItems() {
        var data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text);

        var factory = new CosmeticFactory();

        foreach (CosmeticData item in data.items) {
            var cosmetic = factory.CreateCosmetic(item);

            shopCosmetics.Add(cosmetic);
        }

        ui.FillShopUi(shopCosmetics);
    }
}
