using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static void UseCoins(int amount)
    {
        int coins = PlayerPrefs.GetInt(GameDesignFrontEndConstants.CointKey);
        coins -= amount;
        UpdateCoins(coins);
    }

    public static bool HasEnoughCoins(int amount)
    {
        return (PlayerPrefs.GetInt(GameDesignFrontEndConstants.CointKey) >= amount);
    }

    public static void UpdateCoins(int coint)
    {
        PlayerPrefs.SetInt(GameDesignFrontEndConstants.CointKey, coint);
        Debug.LogWarningFormat("Coint: {0} ", coint);
    }

}
