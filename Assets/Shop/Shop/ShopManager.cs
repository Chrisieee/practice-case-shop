using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        player.UpdateBalance(-price);
        player.inventory.AddItem(item);
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
        }

    }
}
