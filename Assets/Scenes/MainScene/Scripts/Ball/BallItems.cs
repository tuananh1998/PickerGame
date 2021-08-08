public class BallItems
{
    public int Amount;
    public Enums.ItemsType ItemType = Enums.ItemsType.Undefined;

    public BallItems(int amount, Enums.ItemsType type)
    {
        Amount = amount;
        ItemType = type;
    }

    public BallItems(BallItems ballItems)
    {
        Amount = ballItems.Amount;
        ItemType = ballItems.ItemType;
    }

}