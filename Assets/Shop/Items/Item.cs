using System;
using UnityEngine.UI;

public interface IPurchaseStrategy
{
    int GetPrice();
}

public interface IItemState
{
    bool CanBuy();
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public int price;
    public string type;
    public Button button;

    public IPurchaseStrategy strategy;
    public IItemState state;

    public void ChangeState(IItemState newState)
    {
        state = newState;
    }

    public void Buy(ShopManager manager)
    {
        if (state.CanBuy())
        {
            manager.PurchaseItem(this, strategy.GetPrice());
        }
        else
        {
            manager.ui.ShowError("owned");
        }

    }
}

[Serializable]
public class ShopCatalogData
{
    public Item[] items;
}