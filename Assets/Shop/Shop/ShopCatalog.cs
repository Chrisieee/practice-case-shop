using UnityEngine;
using System.Collections.Generic;

public class ShopCatalog : MonoBehaviour {
    private List<Cosmetic> shopCosmetics;
    private TextAsset catalogJson;
    [SerializeField] private ShopUi ui;

    void Awake() {
        GetCatalogItems();
    }

    public void GetCatalogItems() {
        ShopCatalogData data = JsonUtility.FromJson<ShopCatalogData>(catalogJson.text);

        shopCosmetics = new List<Cosmetic>();

        foreach (CosmeticData item in data.items) {
            Cosmetic cosmetic;

            switch (item.type) {
                case "hat":
                    cosmetic = new Hat();
                    break;
                case "pet":
                    cosmetic = new Pet();
                    break;
                case "skin":
                    cosmetic = new Skin();
                    break;
                default:
                    continue;
            }

            cosmetic.id = item.id;
            cosmetic.name = item.name;
            cosmetic.price = item.price;

            shopCosmetics.Add(cosmetic);
        }

        ui.FillShopUi(shopCosmetics);
    }
}
