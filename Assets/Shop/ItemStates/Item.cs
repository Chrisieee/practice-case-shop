using UnityEngine;
using UnityEngine.UI;
using System;

public interface IItemState
{
    void Enter();
    void Exit();
    void Buy();
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public int price;
    public string type;

    public IItemState state;

    public void Initialize(ShopManager shopManager, Button button)
    {
        ChangeState(new AvailableState(this, shopManager, button));
    }

    public void ChangeState(IItemState newState)
    {
        state?.Exit();
        state = newState;
        state.Enter();
    }

    public void Buy()
    {
        state.Buy();
    }
}

[Serializable]
public class ShopCatalogData
{
    public Item[] items;
}