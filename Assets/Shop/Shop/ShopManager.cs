using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public ShopCatalog catalog;
    public ShopUi ui;

    public bool CanAfford(int amount)
    {
        return amount <= player.gemBalance;
    }

    public void PurchaseItem(Cosmetic cosmetic)
    {
        ui.HideError();

        if (!CanAfford(cosmetic.strategy.GetPrice()))
        {
            ui.ShowError("balance");
            return;
        }

        player.UpdateBalance(-cosmetic.strategy.GetPrice());
        player.inventory.AddItem(cosmetic);
    }
}
