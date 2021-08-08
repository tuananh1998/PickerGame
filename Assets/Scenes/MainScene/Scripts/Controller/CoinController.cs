using UnityEngine;
using Scenes.ObjectData;
namespace Scenes.MainScene
{
    public class CoinController : MonoBehaviour
    {
        public static void ChangeCoins(bool subCaculate, int amount)
        {
            int coins = PlayerPrefs.GetInt(GameConstants.CointKey);
            coins = (subCaculate) ? coins - amount : coins + amount;
            UpdateCoins(coins);
        }

        public static bool HasEnoughCoins(int amount)
        {
            return (PlayerPrefs.GetInt(GameConstants.CointKey) >= amount);
        }

        public static void UpdateCoins(int coint)
        {
            PlayerPrefs.SetInt(GameConstants.CointKey, coint);
            Debug.LogWarningFormat("Coint: {0} ", coint);
        }

    }
}