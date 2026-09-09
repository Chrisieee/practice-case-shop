using UnityEngine.UI;

public class SoldOutState : IItemState
{
    private Item item;
    private ShopManager manager;
    private Button button;

    public SoldOutState(Item item, ShopManager manager, Button button)
    {
        this.item = item;
        this.manager = manager;
        this.button = button;
    }

    public void Enter()
    {
        button.interactable = false;
    }

    public void Buy()
    {
        manager.ShowError("soldout");
    }

    public void Exit()
    {

    }
}