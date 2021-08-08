using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

    [System.Serializable]
    public class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
        public bool IsLocked = true;
    }

    public List<ShopItem> ShopItemsList;
    [SerializeField] Animator NoCoinsAnim;


    [SerializeField] GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;
    Button buyBtn;

    void Start()
    {
        int len = ShopItemsList.Count;
        var index = PlayerPrefs.GetInt(GameDesignFrontEndConstants.PurchasedKey);
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            g.transform.GetChild(3).gameObject.SetActive(ShopItemsList[i].IsLocked);
            if (index != 0 && i == index - 1)
            {
                DisableBuyButton();
            }
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }

    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Game.UseCoins(ShopItemsList[itemIndex].Price);
            //purchase Item
            ShopItemsList[itemIndex].IsPurchased = true;

            PlayerPrefs.SetInt(GameDesignFrontEndConstants.PurchasedKey, itemIndex + 1);

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
        // ShopPanel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameDesignFrontEndConstants.BeginScenes);
    }

}
