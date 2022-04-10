using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupLogin : MonoBehaviour
{
    [SerializeField] private ApiController controller;
    [SerializeField] private Popup Popup;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private GameObject CanvasPlay;
    [SerializeField] private GameObject Admin_Button;
    private bool wrongUser = true;
    private bool wrongPwd = true;
    public List<User> usersList = new List<User>();

    // Start is called before the first frame update
    void Start()
    {
        Popup.titleText.text = "Login to play";
        controller.UsersGet(usersList);
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
            controller.UserLogin(userInput.text, passwordInput.text);
        }
    }

    public void login()
    {
        if (controller.errorMessage.Contains("404") || controller.errorMessage.Contains("Cannot connect"))
        {
            Popup.messageText.text = controller.errorMessage;
        }
        else
        {
            GameObject.Find("LoginPopup").SetActive(false);
            GameObject.Find("CanvasLogin").SetActive(false);
            User LoggedInUser = usersList.Find(user => user.username == userInput.text);
            if (!LoggedInUser.admin)
            {
                Admin_Button.SetActive(false);
            }
            else
            {
                Admin_Button.SetActive(true);
            }
            resetForm();
            CanvasPlay.SetActive(true);
        }
    }

    public void resetForm()
    {
        Popup.titleText.text = "Wow!";
        Popup.messageText.text = "";
        controller.errorMessage = "";
        userInput.text = "";
        passwordInput.text = "";
    }
}
