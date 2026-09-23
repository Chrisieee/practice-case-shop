using UnityEngine;

public class ShopManager : MonoBehaviour {
    [SerializeField] private ShopUi ui;
    [SerializeField] private TextAsset catalogJson;
    private Player player;
    private ShopCatalog catalog;

    public void Initialize(Player player) {
        this.player = player;
        catalog = new ShopCatalog();

        catalog.Initialize(catalogJson, ui);
    }

    public bool CanAfford(int amount) {
        return amount <= player.GemBalance;
    }

    public void PurchaseItem(Cosmetic cosmetic) {
        ui.HideError();

        if (!CanAfford(cosmetic.strategy.GetPrice())) {
            ui.ShowError("balance");
            return;
        }

        if (catalog.CheckState(cosmetic) == "owned") {
            ui.ShowError("owned");
            return;
        }

        player.UpdateBalance(-cosmetic.strategy.GetPrice());
        player.inventory.AddItem(cosmetic);
        catalog.ChangeState("owned", cosmetic, ui);
    }
}
