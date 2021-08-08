using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Ball[] BallColumn1;

    [SerializeField]
    private Ball[] BallColumn2;

    [SerializeField]
    private Ball[] BallColumn3;

    [SerializeField]
    private Ball[] SpinBalls;

    [SerializeField]
    private Color[] Colors;

    [SerializeField]
    private BallSetting ballSetting;

    public Queue<int> randomList = new Queue<int>();


    void Awake()
    {
        SpinBalls[0].gameObject.SetActive(false);
        SpinBalls[1].gameObject.SetActive(false);
        SpinBalls[2].gameObject.SetActive(false);
        SpinBalls[0].Number = 0;
        SpawnBall();
    }

    void Start()
    {
        InvokeRepeating("SpinBall", GameDesignFrontEndConstants.WaitTime, GameDesignFrontEndConstants.SpinerTime);
    }

    void SpinBall()
    {
        System.Random random = new System.Random();
        SpinBalls[2].Number = SpinBalls[1].Number;
        SpinBalls[2]._Color = SpinBalls[1]._Color;
        SpinBalls[1].Number = SpinBalls[0].Number;
        SpinBalls[1]._Color = SpinBalls[0]._Color;

        var num = random.Next(GameDesignFrontEndConstants.MinNumber, GameDesignFrontEndConstants.MaxNumber);
        var numColor = random.Next(1, 3);
        SpinBalls[0].Number = num;
        SpinBalls[0]._Color = ballSetting.ballColor[numColor];
        SpinBalls[0].gameObject.SetActive(SpinBalls[0].Number > 0);
        SpinBalls[1].gameObject.SetActive(SpinBalls[1].Number > 0);
        SpinBalls[2].gameObject.SetActive(SpinBalls[2].Number > 0);

    }
    void SpawnBall()
    {
        System.Random random = new System.Random();
        var i = 0;
        foreach (var item in BallColumn1)
        {
            var num = random.Next(GameDesignFrontEndConstants.MinNumber, GameDesignFrontEndConstants.MaxNumber);
            item.Number = num;
            item._Color = ballSetting.ballColor[0];
            var numGift = random.Next(0, 2);
            // Debug.LogWarningFormat("Ball {0} , column 1, itemNumType {1} ", i, numGift);
            // item.BallItem.itemType = (Enums.ItemType)numGift;
            // item.SetBallItemImg(item.BallItem.itemType);
            i++;
        }
        i = 0;
        foreach (var item in BallColumn2)
        {
            var num = random.Next(GameDesignFrontEndConstants.MinNumber, GameDesignFrontEndConstants.MaxNumber);
            item.Number = num;
            item._Color = ballSetting.ballColor[1];
            var numGift = random.Next(0, 2);
            numGift = 2;
            // Debug.LogWarningFormat("Ball {0} , column 2, itemNumType {1}", i, numGift);
            i++;
            if (numGift > 0)
            {
                item.BallItem.ItemType = (Enums.ItemsType)numGift;
                Debug.LogWarningFormat("Item Type {0} ", item.BallItem.ItemType);
                var amount = random.Next(10, 50);
                BallItems ball = new BallItems(item.SetBallItemImg(item.BallItem.ItemType), amount, item.BallItem.ItemType);
                // item.BallItem.ItemType = (Enums.ItemsType)numGift;
                item.BallItem = ball;
                // // item.BallItem.Amount = amount;
            }
        }
        i = 0;
        foreach (var item in BallColumn3)
        {
            var num = random.Next(GameDesignFrontEndConstants.MinNumber, GameDesignFrontEndConstants.MaxNumber);
            item.Number = num;
            item._Color = ballSetting.ballColor[2];
            var numGift = random.Next(0, 2);
            // Debug.LogWarningFormat("Ball {0} , column 3, itemNumType {1}", i, numGift);
            // item.BallItem.itemType = (Enums.ItemType)numGift;
            // item.SetBallItemImg(item.BallItem.itemType);
        }
    }
}