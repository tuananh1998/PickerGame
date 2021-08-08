using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginScenes : MonoBehaviour
{
    [SerializeField]
    private Text Coints;
    bool isFirst = true;
    public void OnPlay()
    {
        SceneManager.LoadScene(GameDesignFrontEndConstants.PlayScenes);
    }

    public void OnShop()
    {
        SceneManager.LoadScene(GameDesignFrontEndConstants.ShopScenes);
    }

    void Start()
    {
        if (isFirst && PlayerPrefs.GetInt(GameDesignFrontEndConstants.FirstRewardKey) == 0)
        {
            PlayerPrefs.SetInt(GameDesignFrontEndConstants.FirstRewardKey, 1);
            PlayerPrefs.SetInt(GameDesignFrontEndConstants.CointKey, GameDesignFrontEndConstants.Coint);
            isFirst = false;
        }
        Coints.text = PlayerPrefs.GetInt(GameDesignFrontEndConstants.CointKey) > GameDesignFrontEndConstants.MaxCoint ? GameDesignFrontEndConstants.FormatCoint : PlayerPrefs.GetInt(GameDesignFrontEndConstants.CointKey).ToString();
    }
}
