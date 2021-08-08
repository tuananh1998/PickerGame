﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region Serialize Field Unity
    [SerializeField]
    private Text timeleft;
    #endregion
    float _totalTime, _waitTime;
    bool _isTimeLeft;

    public static bool IsEndRoundGame;

    void Awake()
    {
        _isTimeLeft = true;
        _totalTime = GameDesignFrontEndConstants.TimeLeft;
        _waitTime = GameDesignFrontEndConstants.WaitTime;
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
}