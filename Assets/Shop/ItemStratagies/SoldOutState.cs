using UnityEngine.UI;
using TMPro;

public class SoldOutState : IItemState
{
    private Item item;
    private Button button;

    public SoldOutState(Item item, Button button)
    {
        this.item = item;
        this.button = button;
    }

    public void Enter()
    {
        button.interactable = false;
    }

    public bool CanBuy()
    {
        return false;
    }

    public void Exit()
    {

    }
}