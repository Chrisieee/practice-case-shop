using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public ShopCatalog catalog;
    public ShopUi ui;

    public bool CanAfford(int amount)
    {
        return amount <= player.gemBalance;
    }

    public void PurchaseItem(Item item)
    {
        ui.HideError();

        if (!CanAfford(item.strategy.GetPrice()))
        {
            ui.ShowError("balance");
            return;
        }

        player.UpdateBalance(-item.strategy.GetPrice());
        player.inventory.AddItem(item);
    }
}
