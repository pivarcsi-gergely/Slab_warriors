using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMinute;
    [SerializeField] private TextMeshProUGUI TextFirstSec;
    [SerializeField] private TextMeshProUGUI TextSecondSec;
    private float timer;
    private bool isButtonClicked;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isButtonClicked)
        {
            UpdateTimerDisplay();
            float minutes = Mathf.Floor(timer / 60);
            float seconds = Mathf.Floor(timer % 60);
            string currentTime = String.Format("{0:0}{1:00}", minutes, seconds);
            TextMinute.text = currentTime[0].ToString();
            TextFirstSec.text = currentTime[1].ToString();
            TextSecondSec.text = currentTime[2].ToString();
        }
        else
        {
            ResetTimer();
        }
        

        /*if (timerDuration == timer)
        {
            matchFound = true;
            ResetTimer();
        }
        else
        {
            matchFound = false;
        }

        if (matchFound)
        {
            PopupWindowAppear();
        }*/
    }

    public void ResetTimer()
    {
        timer = 0;
        isButtonClicked = false;
    }

    public void UpdateTimerDisplay()
    {
        isButtonClicked = true;
        timer += Time.deltaTime;
    }
}
