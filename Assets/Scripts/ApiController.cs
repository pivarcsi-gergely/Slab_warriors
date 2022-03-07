using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using System;

public class ApiController: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI idField, usernameField, bannedField;
    [SerializeField] TextMeshProUGUI[] usersArray;
    private readonly string baseUrl = "http://127.0.0.1:8000/api/users";


    private void Start()
    {
        idField.text = usernameField.text = bannedField.text = "";

        foreach (TextMeshProUGUI user in usersArray)
        {
            user.text = "";
        }
        
        StartCoroutine(GetJsonData(1));
    }

    IEnumerator GetJsonData(int id)
    {
        UnityWebRequest unityReq = UnityWebRequest.Get(baseUrl + "/" + id);

        yield return unityReq.SendWebRequest();

        if (unityReq.result == UnityWebRequest.Result.ProtocolError
            || unityReq.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(unityReq.error);
            yield break;
        }

        JSONNode userInfo = JSON.Parse("{\"users\":" + unityReq.downloadHandler.text + "}");

        User[] users = new User[10];

            users[0] = new User(userInfo["id"], userInfo["username"], userInfo["email"], userInfo["email_verified_at"],
                userInfo["account_number"], userInfo["card_count"], userInfo["fighter_count"], userInfo["level"], userInfo["admin"], userInfo["banned"]);
        

        Debug.Log(userInfo["id"]);
    }

    /* Példányosítás, User osztályként*/

    /*public static User getNewUser()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader sr = new StreamReader(response.GetResponseStream());
        string jsonString = sr.ReadToEnd();
        return JsonUtility.FromJson<User>(jsonString);
    }*/
}
