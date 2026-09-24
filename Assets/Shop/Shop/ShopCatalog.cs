using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class ShopCatalog {
    private List<Cosmetic> shopCosmetics = new();
    private TextAsset catalogJson;
    private ShopUi ui;

    private Dictionary<Cosmetic, string> cosmeticState = new();

    [Inject]
    public void Construct(TextAsset catalogJson, ShopUi shopUi) {
        this.catalogJson = catalogJson;
        ui = shopUi;

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

    public void ChangeState(string state, Cosmetic item) {
        cosmeticState[item] = state;
        ui.ChangeButtonText(state, item);
    }
}
