using UnityEngine;

public class Item : MonoBehaviour
{
    private Enums.ItemsType type;
    private int mount;

    public Enums.ItemsType Type
    {
        get { return type; }
        set
        {
            type = value;
        }
    }
    public void AddItem(int mount)
    {
        this.mount += mount;
    }
}
