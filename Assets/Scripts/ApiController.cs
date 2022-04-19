using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityUITable;

public class ApiController : MonoBehaviour
{
    private readonly static string baseUserUrl = "http://127.0.0.1:8000/api/users";
    private readonly static string baseFighterUrl = "http://127.0.0.1:8000/api/fighters";
    private readonly static string baseCardUrl = "http://127.0.0.1:8000/api/cards";
    [SerializeField] FighterManager fighterManager;
    [SerializeField] Table table;
    [SerializeField] Popup popup;
    [SerializeField] PopupLogin popupLogin;
    public string errorMessage;


    [ContextMenu("Test Get")]
    public async void testGet()
    {
        using var www = UnityWebRequest.Get(baseUserUrl + "/1");

        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        var jsonResponse = www.downloadHandler.text;

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {www.error}");
        }

        try
        {
            var result = JsonConvert.DeserializeObject<User>(jsonResponse);
        }
        catch (Exception ex)
        {

            Debug.LogError(ex.Message);
        }
    }


    public async void UserGet()
    {
        using var www = UnityWebRequest.Get(baseUserUrl + "1");
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        var jsonResponse = www.downloadHandler.text;

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {www.error}");
        }

        try
        {
            var result = JsonConvert.DeserializeObject<User>(jsonResponse);
        }
        catch (Exception ex)
        {

            Debug.LogError(ex.Message);
        }
    }

    public async void UsersGet(IList<User> usersList)
    {

        using var www = UnityWebRequest.Get(baseUserUrl);
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log($"Failed: {www.error}");
        }
        
        try
        {
            usersList = DeserializeToList(www.downloadHandler.text, usersList);
        }
        catch (Exception ex)
        {

            Debug.LogError(ex.Message);
        }
    }

    public static IList<T> DeserializeToList<T>(string jsonString, IList<T> list)
    {
        var array = JArray.Parse(jsonString);

        foreach (var item in array)
        {
            try
            {
                list.Add(item.ToObject<T>());
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        return list;
    }

    public async void UserBan(int index)
    {
        using var www = UnityWebRequest.Post(baseUserUrl + "/" + index + "/ban", index.ToString());
        www.SetRequestHeader("Content-Type", "*/*");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }
    }

    public async void UserUnban(int index)
    {
        using var www = UnityWebRequest.Post(baseUserUrl + "/" + index + "/unban", index.ToString());
        www.SetRequestHeader("Content-Type", "*/*");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }
    }

    public async void UserLogin(string username, string password)
    {
        WWWForm LoginForm = new WWWForm();
        LoginForm.AddField("username", username);
        LoginForm.AddField("password", password);

        using var www = UnityWebRequest.Post(baseUserUrl + "/login", LoginForm);
        www.SetRequestHeader("Authorization", "Bearer");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
            popupLogin.login();
        }
        else
        {
            var message = JsonConvert.DeserializeObject<LoginMessage>(www.downloadHandler.text);
            popup.messageText.text = message.message;
            Debug.Log(www.downloadHandler.text);
            Debug.Log($"Failed: {errorMessage}");
        }
    }

    public async void FightersGet(IList<Fighter> fightersList)
    {

        using var www = UnityWebRequest.Get(baseFighterUrl);
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log($"Failed: {www.error}");
        }

        try
        {
            fightersList = DeserializeToList(www.downloadHandler.text, fightersList);
            fighterManager.FillDropdown();
        }
        catch (Exception ex)
        {

            Debug.LogError(ex.Message);
        }
    }

    public async void CardsGet(IList<Card> cardsList)
    {

        using var www = UnityWebRequest.Get(baseCardUrl);
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log($"Failed: {www.error}");
        }

        try
        {
            cardsList = DeserializeToList(www.downloadHandler.text, cardsList);
        }
        catch (Exception ex)
        {

            Debug.LogError(ex.Message);
        }
    }
}
