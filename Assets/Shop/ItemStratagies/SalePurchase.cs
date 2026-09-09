using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SalePurchase : IPurchaseStrategy
{
    private int price;

    public SalePurchase(int saleAmount, Button button, Item item)
    {
        this.price = Mathf.RoundToInt(item.price * (100 - saleAmount) / 100);
        button.GetComponentInChildren<TMP_Text>().text = item.name + " - from " + item.price + " to " + price + " gems";
    }

    public void Purchase(Item item, ShopManager manager)
    {

        if (!manager.CanAfford(price))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, price);
    }
}