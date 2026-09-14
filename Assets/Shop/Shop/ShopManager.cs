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

    public void PurchaseItem(Item item, int price, Button button)
    {
        player.UpdateBalance(-price);
        player.inventory.AddItem(item);
        item.ChangeState(new OwnedState(item, button));
    }

    public void HideError()
    {
        ui.error.alpha = 0;
    }

    public void ShowError(string type)
    {
        switch (type)
        {
            case "balance":
                ui.error.text = "You don't have enough gems.";
                ui.error.alpha = 1;
                break;
            case "soldout":
                ui.error.text = "This item is sold out.";
                ui.error.alpha = 1;
                break;
            case "owned":
                ui.error.text = "You already own this item.";
                ui.error.alpha = 1;
                break;
        }

    }
}
