using UnityEngine.UI;
using TMPro;

public class NormalPurchase : IPurchaseStrategy
{
    private Button button;
    public NormalPurchase(Button button, Item item)
    {
        this.button = button;
        this.button.GetComponentInChildren<TMP_Text>().text = item.name + " - " + item.price + " gems";
    }
    public void Purchase(Item item, ShopManager manager)
    {
        manager.HideError();

        if (!manager.CanAfford(item.price))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, item.price, button);
    }
}