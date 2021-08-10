using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Scenes.ObjectData;
using Scenes.MainScene;
public class Shop : MonoBehaviour
{
    #region Singlton:Shop

    public static Shop Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #endregion
    #region  Serializable
    [System.Serializable]
    public class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
        public bool IsLocked = true;
    }
    #endregion
    #region SerializeField
    [SerializeField]
    GameObject ItemTemplate;

    [SerializeField]
    Transform ShopScrollView;

    [SerializeField]
    GameObject ShopPanel;

    [SerializeField]
    GameConstants gameConstants;

    [SerializeField]
    AudioData audioData;
    #endregion
    #region Variable
    Button buyBtn;
    GameObject gameObj;
    public List<ShopItem> ShopItemsList;
    #endregion
    #region Function
    void Start()
    {
        int len = ShopItemsList.Count;
        var index = PlayerPrefs.GetInt(gameConstants.PurchasedKey);
        for (int i = 0; i < len; i++)
        {
            gameObj = Instantiate(ItemTemplate, ShopScrollView);
            gameObj.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            gameObj.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = gameObj.transform.GetChild(2).GetComponent<Button>();
            gameObj.transform.GetChild(3).gameObject.SetActive(ShopItemsList[i].IsLocked);
            if (index != 0 && i == index - 1)
            {
                DisableBuyButton();
            }
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }

    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        if (CoinController.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            CoinController.ChangeCoins(true, ShopItemsList[itemIndex].Price);
            //purchase Item
            ShopItemsList[itemIndex].IsPurchased = true;

            PlayerPrefs.SetInt(gameConstants.PurchasedKey, itemIndex + 1);

            //disable the button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();
        }
        else
        {
            Debug.Log("You don't have enough coins!!");
        }
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }
    /*---------------------Close shop--------------------------*/
    public void CloseShop()
    {
        SoundManager.PlaySound(audioData.audioClips[(int)Enums.SoundId.CommonClick]);
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameConstants.BeginScenes);
    }
    #endregion
}
