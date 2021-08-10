using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Scenes.ObjectData;

public class Timer : MonoBehaviour
{
    #region Serialize Field Unity
    [SerializeField]
    private Text timeleft;

    [SerializeField]
    private GameConstants gameConstants;
    #endregion

    #region variable
    float _totalTime, _waitTime;
    bool _isTimeLeft;
    public static bool IsEndRoundGame;
    #endregion

    #region Function
    void Awake()
    {
        _isTimeLeft = true;
        _totalTime = gameConstants.TimeLeft;
        _waitTime = gameConstants.WaitTime;
        //set default time
        UpdateText(_totalTime);
        IsEndRoundGame = false;
    }
    void Update()
    {
        StartCoroutine(CountDownTime(_waitTime));
    }
    IEnumerator CountDownTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (_isTimeLeft)
        {
            if (_totalTime > 0)
            {
                _totalTime -= Time.deltaTime;
                UpdateText(Mathf.FloorToInt(_totalTime) < 0 ? 0 : Mathf.FloorToInt(_totalTime));
            }
            else
            {
                IsEndRoundGame = true;
                _isTimeLeft = false;
            }
        }
    }
    void UpdateText(float time)
    {
        timeleft.text = time.ToString();
    }
    #endregion
}
