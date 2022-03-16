using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUITable;
using TMPro;

public class UserManager : MonoBehaviour
{
    [SerializeField] ApiController controller;
    [SerializeField] Button banConfirmButton;
    [SerializeField] Button unbanConfirmButton;
    [SerializeField] Table table;
    [SerializeField] TextMeshProUGUI banTitleText;
    [SerializeField] TextMeshProUGUI banMessageText;

    
    public IList<User> usersList = new List<User>();

    public void fillUsersList()
    {
        controller.UsersGet(usersList);
        table.UpdateContent();
    }

    public void banUser()
    {
        banTitleText.text = "Ban User";
        banMessageText.text = "Put in the index of the User";


        /*
         * Ezt egy button OnClick event-jével meghívjuk
         * Minden egyes meghívásnál elõjön egy pici form, ami kéri a sor indexét (természetesen Cancel button)
         * Ezt el lehet menteni, amit tovább lehet küldeni az UserPut-nak, az pedig feldolgozza
         * Ha ez megvan, újra lekérjük a content-et
         */
    }

    public void unbanUser()
    {
        banTitleText.text = "Unban User";
        banMessageText.text = "Put in the index of the User";
    }
}
