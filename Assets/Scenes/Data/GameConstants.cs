using UnityEngine;

namespace Scenes.ObjectData
{
    [CreateAssetMenu(menuName = "Menu/Create Game Constant")]
    public class GameConstants : ScriptableObject
    {
        [SerializeField]
        public int TimeLeft = 30;
        [SerializeField]
        public int MinNumber = 1;
        [SerializeField]
        public int MaxNumber = 50;
        [SerializeField]
        public float WaitTime = 0.5f;
        [SerializeField]
        public float SpinerTime = 2f;
        [SerializeField]
        public string StampCountKey = "StampCount";
        public string BeginScenes = "BeginScenes";
        [SerializeField]
        public string PlayScenes = "MainScene";
        [SerializeField]
        public string SummaryScenes = "EndScenes";
        [SerializeField]
        public string ShopScenes = "ShopScenes";
        [SerializeField]
        public const string CointKey = "Coint";
        [SerializeField]
        public int Coint = 500;
        [SerializeField]
        public string PurchasedKey = "Purchased";
        [SerializeField]
        public int MaxCoint = 9999999;
        [SerializeField]
        public string FormatCoint = "999999+";
        [SerializeField]
        public string FirstRewardKey = "FirstReward";
        [SerializeField]
        public int maxCointRandom = 50;
        [SerializeField]
        public int minCointRandom = 5;
        [SerializeField]
        public int minItemRandom = 0;
        [SerializeField]
        public int maxItemRandom = 5;

    }
}
