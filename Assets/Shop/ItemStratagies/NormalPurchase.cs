using UnityEngine.UI;
using TMPro;

public class NormalPurchase : IPurchaseStrategy
{
    public NormalPurchase(Button button, Item item)
    {
        button.GetComponentInChildren<TMP_Text>().text = item.name + " - " + item.price + " gems";
    }
    public void Purchase(Item item, ShopManager manager)
    {
        if (!manager.CanAfford(item.price))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, item.price);
    }
}