using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject SpinHolder;

    [SerializeField]
    private string SpinBallTag = "SpinBall";

    [SerializeField]
    private Sprite StampSprite;

    [SerializeField]
    Ball[] balls;

    [SerializeField]
    AudioClip[] audioClips;

    GameObject[] spinBalls;

    int _stampCount = 0;
    bool _isCheck1, _isCheck2, _isCheck3, _isCheck4, _isCheck5, _isCheck6, _isCheck7, _isCheck8 = false;
    void Start()
    {
        _isCheck1 = _isCheck2 = _isCheck3 = _isCheck4 = _isCheck5 = _isCheck6 = _isCheck7 = _isCheck8 = false;
        _stampCount = 0;
        InvokeRepeating("GetListSpinBalls", GameDesignFrontEndConstants.WaitTime, GameDesignFrontEndConstants.SpinerTime);
        InvokeRepeating("HintBox", GameDesignFrontEndConstants.WaitTime, 0.25f);
    }

    void Update()
    {
        if (Timer.IsEndRoundGame)
        {
            CancelInvoke();
            Time.timeScale = 0;
            Debug.LogWarningFormat("Game Over");
            SceneManager.LoadScene(GameDesignFrontEndConstants.SummaryScenes);
            PlayerPrefs.SetInt(GameDesignFrontEndConstants.StampCountKey, _stampCount);
        }
    }
    void GetListSpinBalls()
    {
        spinBalls = GameObject.FindGameObjectsWithTag(SpinBallTag);

        if (CheckBingo() > 0)
        {
            Debug.LogWarning("BINGO");
            SoundManager.PlaySound(audioClips[0]);

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
        foreach (var spinBall in spinBalls)
        {
            var _spinBall = spinBall.GetComponent<Ball>();
            if (ball.IsHint || ball.Number == _spinBall.Number && ball._Color == _spinBall._Color)
            {
                ball.SetStamp(true);
                SoundManager.PlaySound(audioClips[1]);
                ball.gameObject.GetComponent<Button>().interactable = false;
                ball.Number = 0;
                ball.GetComponent<Animator>().SetBool("IsStop", true);
                _stampCount++;
                if (CheckBingo() > 0)
                {
                    Debug.LogWarning("BINGO");
                    SoundManager.PlaySound(audioClips[0]);
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
            SoundManager.PlaySound(audioClips[2]);
            Debug.LogWarningFormat("Wrong!!!");
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
        balls[0].SetStamp(true);
        balls[0].GetComponent<Button>().interactable = false;
        balls[3].SetStamp(true);
        balls[3].GetComponent<Button>().interactable = false;
        balls[5].SetStamp(true);
        balls[5].GetComponent<Button>().interactable = false;
    }

    public void OnBack()
    {
        SceneManager.LoadScene(GameDesignFrontEndConstants.BeginScenes);
    }
}
