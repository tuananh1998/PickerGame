using UnityEngine;
using UnityEngine.UI;
using Scenes.ObjectData;
namespace Scenes.MainScene.BallHandler
{
    public class Ball : MonoBehaviour
    {

        #region Properties

        private Color color;

        private int number;

        private bool isHint;

        private BallItems ballItem;

        #endregion

        #region  SerializeField

        [SerializeField]
        private Text numText;

        [SerializeField]
        private GameObject stamp;

        [SerializeField]
        private bool isStamp = false;

        [SerializeField]
        private BallSetting ballSetting;

        [SerializeField]
        private Image ballItemImg;

        #endregion

        #region  Geter and Seter

        public Color _Color
        {
            get { return color; }
            set
            {
                color = value;
                numText.color = value;
            }
        }
        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                numText.text = value.ToString();
            }
        }
        public bool IsHint
        {
            get { return isHint; }
            set
            {
                isHint = value;
            }
        }
        public bool IsStamp
        {
            get { return isStamp; }
            set
            {
                isStamp = value;
            }
        }

        public BallItems BallItem { get => ballItem; set => ballItem = value; }

        #endregion

        #region Function
        public void SetStamp(bool isActive)
        {
            // stamp.SetActive(isActive);
            gameObject.GetComponent<Animator>().Play("Stamp");
            IsStamp = isActive;
        }

        public void SetItemImage(Sprite itemImg)
        {
            if (itemImg != null)
            {
                ballItemImg.sprite = itemImg;
            }
            ballItemImg.gameObject.SetActive(itemImg != null);
        }

        public Sprite SetBallItemImg(Enums.ItemsType itemType)
        {
            switch (itemType)
            {
                case Enums.ItemsType.Undefined:
                    return null;
                case Enums.ItemsType.Stamp:
                    return ballSetting.ballItem[0];
                case Enums.ItemsType.Coint:
                    return ballSetting.ballItem[1];
            }
            return null;
        }
    }
    #endregion
}