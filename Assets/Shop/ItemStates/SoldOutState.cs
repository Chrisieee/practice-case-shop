public class SoldOutState : IItemState
{
    private Item item;
    private ShopManager manager;

    public SoldOutState(Item item, ShopManager manager)
    {
        this.item = item;
        this.manager = manager;
    }

    public void Enter()
    {
        //show that it is soldout
    }

    public void Buy()
    {
        manager.ShowError("soldout");
    }

    public void Exit()
    {

    }
}