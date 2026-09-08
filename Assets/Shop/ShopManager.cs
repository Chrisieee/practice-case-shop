using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public ShopCatalog catalog;
    public ShopUi ui;

    public void PurchaseItem(Item item) {
        ui.error.alpha = 0;

        if (player.CheckBalance(item.price)) {
            player.UpdateBalance(- + item.price);
            print("Item purchased");
            player.inventory.AddItem(item);
        } else {
            ui.ShowError();
            Debug.Log("Not enough balance");
        }
    }
}
