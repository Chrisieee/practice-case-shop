public class AvailableState : IItemState
{
    private Item item;
    private ShopManager manager;

    public AvailableState(Item item, ShopManager manager)
    {
        this.item = item;
        this.manager = manager;
    }

    public void Enter()
    {
        //show that is available
    }

    public void Buy()
    {
        if (!manager.CanAfford(item.price))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, item.price);
        item.ChangeState(new SoldOutState(item, manager));
    }

    public void Exit()
    {

    }
}