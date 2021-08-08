using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Create Ball Setting")]
public class BallSetting : ScriptableObject
{
    [SerializeField]
    public Sprite[] ballItem;

    [SerializeField]
    public Color[] ballColor;
}