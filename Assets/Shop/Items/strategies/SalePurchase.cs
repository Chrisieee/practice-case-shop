using UnityEngine;

public class SalePurchase : IPurchaseStrategy
{
    public int price;

    public SalePurchase(int saleAmount, Cosmetic cosmetic)
    {
        price = Mathf.RoundToInt(cosmetic.price * (100 - saleAmount) / 100);
    }

    public int GetPrice()
    {
        return price;
    }
}