using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scenes.MainScene.BallHandler;
using Scenes.ObjectData;

namespace Scenes.MainScene
{
    public class Controller : MonoBehaviour
    {
        #region  SerializeField
        [SerializeField]
        private GameObject SpinHolder;

        [SerializeField]
        private string SpinBallTag = "SpinBall";

        [SerializeField]
        private Sprite StampSprite;

        [SerializeField]
        Ball[] balls;

        [SerializeField]
        private AudioData audioSettings;

        [SerializeField]
        private GameConstants gameConstants;

        #endregion
        GameObject[] spinBalls;
        int _stampCount = 0;
        bool _isCheck1, _isCheck2, _isCheck3, _isCheck4, _isCheck5, _isCheck6, _isCheck7, _isCheck8 = false;
        void Start()
        {
            _isCheck1 = _isCheck2 = _isCheck3 = _isCheck4 = _isCheck5 = _isCheck6 = _isCheck7 = _isCheck8 = false;
            _stampCount = 0;
            InvokeRepeating("GetListSpinBalls", gameConstants.WaitTime, gameConstants.SpinerTime);
            InvokeRepeating("HintBox", gameConstants.WaitTime, 0.25f);
        }

        void Update()
        {
            if (Timer.IsEndRoundGame)
            {
                CancelInvoke();
                Time.timeScale = 0;
                Debug.LogWarningFormat("Game Over");
                SceneManager.LoadScene(gameConstants.SummaryScenes);
                PlayerPrefs.SetInt(gameConstants.StampCountKey, _stampCount);
            }
        }
        void GetListSpinBalls()
        {
            spinBalls = GameObject.FindGameObjectsWithTag(SpinBallTag);

            if (CheckBingo() > 0)
            {
                Debug.LogWarning("BINGO");
                SoundManager.PlaySound(audioSettings.audioClips[(int)Enums.SoundId.Bingo]);

            }
        }

        void HintBox()
        {
            foreach (var spinBall in spinBalls)
            {
                var _spinBall = spinBall.GetComponent<Ball>();
                foreach (var item in balls)
                {
                    var ball = item.GetComponent<Ball>();
                    if (ball.Number == _spinBall.Number && ball._Color == _spinBall._Color)
                    {
                        item.gameObject.GetComponent<Animator>().Play("Hint", 0);
                        ball.IsHint = true;
                    }
                }
            }
        }

        public void OnClick(Ball ball)
        {
            var isWrong = true;
            if (spinBalls != null)
            {
                foreach (var spinBall in spinBalls)
                {
                    var _spinBall = spinBall.GetComponent<Ball>();
                    if (ball.IsHint || ball.Number == _spinBall.Number && ball._Color == _spinBall._Color)
                    {
                        if (ball.BallItem != null)
                        {
                            ball.SetItemImage(null);
                            if (ball.BallItem.ItemType == Enums.ItemsType.Stamp)
                            {
                                _stampCount += ball.BallItem.Amount;
                            }
                            else if (ball.BallItem.ItemType == Enums.ItemsType.Coint)
                            {
                                CoinController.ChangeCoins(false, ball.BallItem.Amount);
                            }
                        }
                        ball.SetStamp(true);
                        SoundManager.PlaySound(audioSettings.audioClips[(int)Enums.SoundId.Stamp]);
                        ball.gameObject.GetComponent<Button>().interactable = false;
                        ball.Number = 0;
                        ball.GetComponent<Animator>().SetBool("IsStop", true);
                        _stampCount++;
                        if (CheckBingo() > 0)
                        {
                            Debug.LogWarning("BINGO");
                            SoundManager.PlaySound(audioSettings.audioClips[(int)Enums.SoundId.Bingo]);
                        }
                    }

                    isWrong = !(ball.IsHint || ball.Number == _spinBall.Number);
                    if (!isWrong)
                    {
                        // exit it loop
                        break;
                    }
                }
                if (isWrong)
                {
                    SoundManager.PlaySound(audioSettings.audioClips[(int)Enums.SoundId.WrongClick]);
                    Debug.LogWarningFormat("Wrong!!!");
                }
            }

        }

        int CheckBingo()
        {
            #region Horzontal Winning Condtion
            if (balls[0].IsStamp && balls[3].IsStamp && balls[5].IsStamp && !_isCheck1)
            {
                _isCheck1 = true;
                return 1;
            }
            else if (balls[1].IsStamp && balls[6].IsStamp && !_isCheck2)
            {
                _isCheck2 = true;
                return 1;
            }
            else if (balls[2].IsStamp && balls[4].IsStamp && balls[7].IsStamp && !_isCheck3)
            {
                _isCheck3 = true;
                return 1;
            }
            #endregion

            #region Vertical Winning Condtion
            if (balls[0].IsStamp && balls[1].IsStamp && balls[2].IsStamp && !_isCheck4)
            {
                _isCheck4 = true;
                return 1;
            }
            else if (balls[3].IsStamp && balls[4].IsStamp && !_isCheck5)
            {
                _isCheck5 = true;
                return 1;
            }
            else if (balls[5].IsStamp && balls[6].IsStamp && balls[7].IsStamp && !_isCheck6)
            {
                _isCheck6 = true;
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            if (balls[0].IsStamp && balls[7].IsStamp && !_isCheck7)
            {
                _isCheck7 = true;
                return 1;
            }
            else if (balls[5].IsStamp && balls[2].IsStamp && !_isCheck8)
            {
                _isCheck8 = true;
                return 1;
            }
            #endregion

            return -1;
        }

        public void OnDebugCheatBingo(Button cheatBtn)
        {
            cheatBtn.interactable = false;
            CheatOnceBallBox(balls[0]);
            CheatOnceBallBox(balls[3]);
            CheatOnceBallBox(balls[5]);
        }

        public void CheatOnceBallBox(Ball ballBtn)
        {
            ballBtn.SetStamp(true);
            ballBtn.Number = 0;
            ballBtn.GetComponent<Button>().interactable = false;
        }

        public void OnBack()
        {
            SoundManager.PlaySound(audioSettings.audioClips[(int)Enums.SoundId.CommonClick]);
            SceneManager.LoadScene(gameConstants.BeginScenes);
        }
    }
}