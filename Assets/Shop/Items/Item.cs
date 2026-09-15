using System;

public interface IPurchaseStrategy
{
    int GetPrice();
}

[Serializable]
public class Cosmetic
{
    public int id;
    public string name;
    public int price;
    public string type;

    public IPurchaseStrategy strategy;

    public void Buy(ShopManager manager)
    {
        manager.PurchaseItem(this);
    }
}