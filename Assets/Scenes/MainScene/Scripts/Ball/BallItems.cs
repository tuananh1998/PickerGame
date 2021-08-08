
using UnityEngine;

public class BallItems
{
    public Sprite ItemImage;
    public int Amount;
    public Enums.ItemsType ItemType = Enums.ItemsType.Undefined;

    public BallItems(Sprite itemImg, int amount, Enums.ItemsType type)
    {
        ItemImage = itemImg;
        Amount = amount;
        ItemType = type;
    }

    public BallItems(BallItems ballItems)
    {
        ItemImage = ballItems.ItemImage;
        Amount = ballItems.Amount;
        ItemType = ballItems.ItemType;
    }

}