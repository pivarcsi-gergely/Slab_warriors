using System.Collections.Generic;
using UnityEngine;
using UnityUITable;
using TMPro;

public class UserManager : MonoBehaviour
{
    [SerializeField] ApiController controller;
    [SerializeField] TMP_InputField input_userid;
    [SerializeField] Table table;
    [SerializeField] TextMeshProUGUI banTitleText;
    [SerializeField] TextMeshProUGUI banMessageText;


    public List<User> usersList = new List<User>();

    public void FillUsersList()
    {
        controller.UsersGet(usersList);
        table.UpdateContent();
        usersList.Clear();
    }

    public void BanUserSetup()
    {
        banTitleText.text = "Ban User";
        banMessageText.text = "Put in the index of the User";
        input_userid.Select();
    }

    public void BanUser()
    {
        if (banTitleText.text != "Ban User")
        {
            UnbanUser();
        }
        else
        {
            BanUserSetup();
            controller.UserBan(int.Parse(input_userid.text));
            FillUsersList();
            FormReset();
        }
    }

    public void UnbanUserSetup()
    {
        banTitleText.text = "Unban User";
        banMessageText.text = "Put in the index of the User";
    }

    public void UnbanUser()
    {
        UnbanUserSetup();
        controller.UserUnban(int.Parse(input_userid.text));
        FillUsersList();
        FormReset();
    }

    public void FormReset()
    {
        banTitleText.text = "Hmm";
        banMessageText.text = "Hmmmmmmmmmmmmmmmmmmmmmmmm";
        input_userid.text = "";
    }
}
