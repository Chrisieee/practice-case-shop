public class SaleState : IItemState
{
    private Item item;
    private ShopManager manager;
    private int salesPrice;

    public SaleState(Item item, ShopManager manager, int saleAmount)
    {
        this.item = item;
        this.manager = manager;
        salesPrice = item.price * (100 - saleAmount) / 100;
    }

    public void Enter()
    {
        //show that it is on sale
    }

    public void Buy()
    {
        if (!manager.CanAfford(salesPrice))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, salesPrice);
        item.ChangeState(new SoldOutState(item, manager));
    }

    public void Exit()
    {

    }
}