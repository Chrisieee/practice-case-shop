public class FreePurchase : IPurchaseStrategy
{
    public int price = 0;

    public int GetPrice()
    {
        return price;
    }
}