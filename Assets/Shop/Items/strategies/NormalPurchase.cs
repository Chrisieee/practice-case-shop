public class NormalPurchase : IPurchaseStrategy
{
    private int price;

    public NormalPurchase(Cosmetic cosmetic)
    {
        price = cosmetic.price;
    }

    public int GetPrice()
    {
        return price;
    }
}