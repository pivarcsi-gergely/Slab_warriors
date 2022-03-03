using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PopupLogin : MonoBehaviour
{
    [SerializeField] private Popup Popup;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private GameObject CanvasPlay;
    private bool wrongUser = true;
    private bool wrongPwd = true;

    // Start is called before the first frame update
    void Start()
    {
        Popup.titleText.text = "Login to play";

    }

    public void inputCheck()
    {
        if (string.IsNullOrEmpty(userInput.text) || string.IsNullOrEmpty(passwordInput.text))
        {
            Popup.messageText.text = "None of the inputs can be empty.";
            wrongUser = true;
            wrongPwd = true;
        }
        else if (string.IsNullOrEmpty(userInput.text))
        {
            Popup.messageText.text = "The username input cannot be empty.";
            wrongUser = true;
        }
        else if (string.IsNullOrEmpty(passwordInput.text))
        {
            Popup.messageText.text = "The password input cannot be empty.";
            wrongPwd = true;
        }
        else
        {
            wrongPwd = false;
            wrongUser = false;
        }

        if (!wrongPwd && !wrongUser)
        {
            login();
        }


    }

    private void login()
    {
        GameObject.Find("ApplyPopup").SetActive(false);
        GameObject.Find("CanvasLogin").SetActive(false);
        CanvasPlay.SetActive(true);
    }
}
