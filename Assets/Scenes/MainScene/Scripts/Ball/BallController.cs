using UnityEngine;
using Scenes.ObjectData;
namespace Scenes.MainScene.BallHandler
{
    public class BallController : MonoBehaviour
    {
        #region  SerializeField
        [SerializeField]
        private Ball[] BallColumn1;

        [SerializeField]
        private Ball[] BallColumn2;

        [SerializeField]
        private Ball[] BallColumn3;

        [SerializeField]
        private Ball[] SpinBalls;

        [SerializeField]
        private BallSetting ballSetting;

        [SerializeField]
        private GameConstants gameConstants;
        #endregion

        #region Function
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
            InvokeRepeating("SpinBall", gameConstants.WaitTime, gameConstants.SpinerTime);
        }

        void SpinBall()
        {
            System.Random random = new System.Random();
            SpinBalls[2].Number = SpinBalls[1].Number;
            SpinBalls[2]._Color = SpinBalls[1]._Color;
            SpinBalls[1].Number = SpinBalls[0].Number;
            SpinBalls[1]._Color = SpinBalls[0]._Color;

            var num = random.Next(gameConstants.MinNumber, gameConstants.MaxNumber);
            var numColor = random.Next(0, ballSetting.ballColor.Length);
            SpinBalls[0].Number = num;
            SpinBalls[0]._Color = ballSetting.ballColor[numColor];
            SpinBalls[0].gameObject.SetActive(SpinBalls[0].Number > 0);
            SpinBalls[1].gameObject.SetActive(SpinBalls[1].Number > 0);
            SpinBalls[2].gameObject.SetActive(SpinBalls[2].Number > 0);

        }
        void SpawnBall()
        {
            SpawnBallInColumn(BallColumn1, ballSetting.ballColor[0]);
            SpawnBallInColumn(BallColumn2, ballSetting.ballColor[1]);
            SpawnBallInColumn(BallColumn3, ballSetting.ballColor[2]);
        }

        public void SpawnBallInColumn(Ball[] balls, Color color)
        {
            System.Random random = new System.Random();
            foreach (var item in balls)
            {
                var num = random.Next(gameConstants.MinNumber, gameConstants.MaxNumber);
                item.Number = num;
                item._Color = color;
                var numGift = random.Next(gameConstants.MinItemRandom, gameConstants.MaxItemRandom);
                if (numGift > 0)
                {
                    if (numGift > 2)
                    {
                        numGift = 0;
                    }
                    var itemType = (Enums.ItemsType)numGift;
                    var amount = random.Next(gameConstants.MinCointRandom, gameConstants.MaxCointRandom);
                    BallItems ball = new BallItems(amount, itemType);
                    item.BallItem = ball;
                    // Debug.LogWarningFormat("Item type: {0} ", itemType);
                    item.SetItemImage(item.SetBallItemImg(itemType));
                }
            }
        }
    }
    #endregion
}