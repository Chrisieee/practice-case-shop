public class SoldOutState : IItemState
{
    public bool CanBuy()
    {
        return false;
    }
}