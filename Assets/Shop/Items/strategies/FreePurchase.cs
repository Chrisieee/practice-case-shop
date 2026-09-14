using UnityEngine.UI;
using TMPro;

public class FreePurchase : IPurchaseStrategy
{
    private Button button;

    public FreePurchase(Button button, Item item)
    {
        this.button = button;
        this.button.GetComponentInChildren<TMP_Text>().text = item.name + " - from " + item.price + " to " + 0 + " gems";
    }

    public void Purchase(Item item, ShopManager manager)
    {
        manager.HideError();

        if (!manager.CanAfford(0))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, 0, button);
    }
}