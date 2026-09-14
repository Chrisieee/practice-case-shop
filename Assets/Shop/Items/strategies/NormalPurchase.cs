public class NormalPurchase : IPurchaseStrategy
{
    private int price;

    public NormalPurchase(Item item)
    {
        price = item.price;
    }

    public int GetPrice()
    {
        return price;
    }
}