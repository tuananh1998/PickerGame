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
        [SerializeField]
        public string CoinCountKey = "CoinCount";
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
        public int MaxCointRandom = 50;
        [SerializeField]
        public int MinCointRandom = 5;
        [SerializeField]
        public int MinItemRandom = 0;
        [SerializeField]
        public int MaxItemRandom = 5;
        [SerializeField]
        public const string MuteSoundKey = "MuteSound";
        [SerializeField]
        public Color MuteSoundColor;
        [SerializeField]
        public Color NormalSoundColor;
    }
}
