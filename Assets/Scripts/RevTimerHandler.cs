using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RevTimerHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMinute;
    [SerializeField] private TextMeshProUGUI TextFirstSec;
    [SerializeField] private TextMeshProUGUI TextSecondSec;
    private float timer;
    private bool isButtonClicked;
    //public string InitialMenu_Canvas = "InitialMenu_Canvas";
    //public string CanvasTimer = "CanvasTimer";
    [SerializeField] private Button readyButton = null;
    [SerializeField] private GameObject CanvasTimer = null;
    [SerializeField] private GameObject InitialMenu_Canvas = null;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        isButtonClicked = true;
        startRemoveTimer();
    }

    private void startRemoveTimer()
    {
        StartCoroutine(ready(timer));
    }

    public IEnumerator<WaitForSeconds> ready(float seconds)
    {
        readyButton.onClick.AddListener(buttonClicked);
        yield return new WaitForSeconds(seconds);
            InitialMenu_Canvas.SetActive(false);
            CanvasTimer.SetActive(false);
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
    }

    public void ResetTimer()
    {
        timer = 11;
        isButtonClicked = false;
    }

    public void readyButtonVersion()
    {
        if (isButtonClicked)
        {
            InitialMenu_Canvas.SetActive(false);
            CanvasTimer.SetActive(false);
            StopAllCoroutines();
        }
    }


    public void buttonClicked()
    {
        isButtonClicked = true;
    }

    public void UpdateTimerDisplay()
    {
        isButtonClicked = true;
        timer -= Time.deltaTime;

        if (timer == 0 || timer < 0)
        {
            timer = 0;
        }
    }
}
