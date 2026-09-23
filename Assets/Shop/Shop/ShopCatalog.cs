using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog {
    private List<Cosmetic> shopCosmetics = new List<Cosmetic>();
    private TextAsset catalogJson;
    private ShopUi ui;

    private Dictionary<Cosmetic, string> cosmeticState = new();

    public void Initialize(TextAsset catalogJson, ShopUi ui) {
        this.catalogJson = catalogJson;
        this.ui = ui;

        GetCatalogItems();
    }

    public void GetCatalogItems() {
        var data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text);

        var factory = new CosmeticFactory();

        foreach (CosmeticData item in data.items) {
            var cosmetic = factory.CreateCosmetic(item);

            shopCosmetics.Add(cosmetic);
            cosmeticState.Add(cosmetic, "available");
        }

        ui.FillShopUi(shopCosmetics);
    }

    public string CheckState(Cosmetic item) {
        return cosmeticState[item];
    }

    public void ChangeState(string state, Cosmetic item, ShopUi ui) {
        cosmeticState[item] = state;
        ui.ChangeButtonText(state, item);
    }
}
