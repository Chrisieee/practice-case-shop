using UnityEngine;

public class SalePurchase : IPurchaseStrategy
{
    public int price;

    public SalePurchase(int saleAmount, Item item)
    {
        price = Mathf.RoundToInt(item.price * (100 - saleAmount) / 100);
    }

    public int GetPrice()
    {
        return price;
    }
}