using UnityEngine.UI;
using TMPro;

public class AvailableState : IItemState
{
    private Item item;
    private Button button;

    public AvailableState(Item item, Button button)
    {
        this.item = item;
        this.button = button;
    }

    public void Enter()
    {
        button.interactable = true;
    }

    public bool CanBuy()
    {
        return true;
    }

    public void Exit()
    {

    }
}