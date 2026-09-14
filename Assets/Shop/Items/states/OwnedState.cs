using UnityEngine.UI;
using TMPro;
using System;

public class OwnedState : IItemState
{
    private Item item;
    private Button button;

    public OwnedState(Item item, Button button)
    {
        this.item = item;
        this.button = button;
    }

    public void Enter()
    {
        button.GetComponentInChildren<TMP_Text>().text = item.name + " - " + "Owned";
    }

    public bool CanBuy()
    {
        return false;
    }

    public void Exit()
    {

    }
}