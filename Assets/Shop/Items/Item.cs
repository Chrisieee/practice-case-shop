using System;

public interface IPurchaseStrategy
{
    void Purchase(Item item, ShopManager manager);
}

public interface IItemState
{
    void Enter();
    void Exit();
    bool CanBuy();
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public int price;
    public string type;

    public IPurchaseStrategy strategy;
    public IItemState state;

    public void ChangeState(IItemState newState)
    {
        state?.Exit();
        state = newState;
        state.Enter();
    }

    public void Buy(ShopManager manager)
    {
        if (state.CanBuy())
        {
            strategy.Purchase(this, manager);
        }
        else
        {
            manager.ShowError("owned");
        }

    }
}

[Serializable]
public class ShopCatalogData
{
    public Item[] items;
}