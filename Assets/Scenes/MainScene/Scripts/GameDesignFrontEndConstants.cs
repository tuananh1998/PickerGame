using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Create GameDesignFrontEndConstants")]
public class GameDesignFrontEndConstants : ScriptableObject
{
    [SerializeField]
    public const int TimeLeft = 30;
    [SerializeField]
    public const int MinNumber = 1;
    [SerializeField]
    public const int MaxNumber = 50;
    [SerializeField]
    public const float WaitTime = 0.5f;
    [SerializeField]
    public const float SpinerTime = 2f;
    [SerializeField]
    public const string StampCountKey = "StampCount";
    public const string BeginScenes = "BeginScenes";
    [SerializeField]
    public const string PlayScenes = "MainScene";
    [SerializeField]
    public const string SummaryScenes = "EndScenes";
    [SerializeField]
    public const string ShopScenes = "ShopScenes";
    [SerializeField]
    public const string CointKey = "Coint";
    [SerializeField]
    public const int Coint = 500;
    [SerializeField]
    public const string PurchasedKey = "Purchased";
    [SerializeField]
    public const int MaxCoint = 9999999;
    [SerializeField]
    public const string FormatCoint = "999999+";
    [SerializeField]
    public const string FirstRewardKey = "FirstReward";

}

