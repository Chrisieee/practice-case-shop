using UnityEngine.UI;
using TMPro;

public class AvailableState : IItemState
{
    private Item item;
    private ShopManager manager;
    private Button button;

    public AvailableState(Item item, ShopManager manager, Button button)
    {
        this.item = item;
        this.manager = manager;
        this.button = button;
    }

    public void Enter()
    {
        button.GetComponentInChildren<TMP_Text>().text = item.name + " - " + item.price + " gems";
    }

    public void Buy()
    {
        if (!manager.CanAfford(item.price))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, item.price);
        item.ChangeState(new SoldOutState(item, manager, button));
    }

    public void Exit()
    {

    }
}