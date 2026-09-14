using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SalePurchase : IPurchaseStrategy
{
    private int price;
    private Button button;

    public SalePurchase(int saleAmount, Button button, Item item)
    {
        this.button = button;
        price = Mathf.RoundToInt(item.price * (100 - saleAmount) / 100);
        this.button.GetComponentInChildren<TMP_Text>().text = item.name + " - from " + item.price + " to " + price + " gems";
    }

    public void Purchase(Item item, ShopManager manager)
    {
        manager.HideError();

        if (!manager.CanAfford(price))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, price, button);
    }
}