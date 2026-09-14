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

    public void PurchaseItem(Item item, int price)
    {
        ui.HideError();

        if (!CanAfford(price))
        {
            ui.ShowError("balance");
            return;
        }

        player.UpdateBalance(-price);
        player.inventory.AddItem(item);

        item.ChangeState(new OwnedState());
        ui.ChangeButtonText("owned", item);
    }
}
