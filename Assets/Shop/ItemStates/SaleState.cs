using UnityEngine.UI;
using TMPro;

public class SaleState : IItemState
{
    private Item item;
    private ShopManager manager;
    private Button button;
    private int salesPrice;

    public SaleState(Item item, ShopManager manager, int saleAmount, Button button)
    {
        this.item = item;
        this.manager = manager;
        salesPrice = item.price * (100 - saleAmount) / 100;
        this.button = button;
    }

    public void Enter()
    {
        button.GetComponentInChildren<TMP_Text>().text = item.name + " - from " + item.price + " to " + salesPrice + " gems";
    }

    public void Buy()
    {
        if (!manager.CanAfford(salesPrice))
        {
            manager.ShowError("balance");
            return;
        }

        manager.PurchaseItem(item, salesPrice);
        item.ChangeState(new SoldOutState(item, manager, button));
    }

    public void Exit()
    {

    }
}