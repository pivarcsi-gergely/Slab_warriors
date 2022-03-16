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
    private readonly static string baseUrl = "http://127.0.0.1:8000/api/users";
    [SerializeField] Table table;


    [ContextMenu("Test Get")]
    public async void testGet()
    {
        using var www = UnityWebRequest.Get(baseUrl + "/1");

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
        using var www = UnityWebRequest.Get(baseUrl + "1");
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

        using var www = UnityWebRequest.Get(baseUrl);
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
            Debug.Log(www.downloadHandler.text);
            Debug.Log($"Failed: {www.error}");
        }
        
        try
        {
            usersList = DeserializeToList<User>(jsonResponse, usersList);
            table.UpdateContent();
            foreach (var user in usersList)
            {
                Debug.Log(user.banned);
            }
        }
        catch (Exception ex)
        {

            Debug.LogError(ex.Message);
        }
    }

    public static IList<T> DeserializeToList<T>(string jsonString, IList<T> usersList)
    {
        var array = JArray.Parse(jsonString);

        foreach (var item in array)
        {
            try
            {
                usersList.Add(item.ToObject<T>());
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        return usersList;
    }

    public async void UserPut(int index)
    {
        //jsonBody, ami elmegy a PUT-tal
        using var www = UnityWebRequest.Put("http://127.0.0.1:8000/admin/users" + "/" + index, "");
        www.SetRequestHeader("Content-Type", "application/json");
        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }
    }
}
