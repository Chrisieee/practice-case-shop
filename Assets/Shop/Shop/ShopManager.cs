using Zenject;

public class ShopManager {
    private ShopUi ui;
    private Player player;
    private ShopCatalog catalog;

    [Inject]
    public void Construct(Player player, ShopCatalog catalog, ShopUi shopUi) {
        this.player = player;
        this.catalog = catalog;
        ui = shopUi;
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
        catalog.ChangeState("owned", cosmetic);
    }
}
