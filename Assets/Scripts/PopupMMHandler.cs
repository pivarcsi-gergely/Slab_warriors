using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupMMHandler : MonoBehaviour
{
    [SerializeField] private Popup Popup;
    [SerializeField] SceneHandler SceneHandler = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDown());

    }

    IEnumerator countDown()
    {
        Popup.titleText.text = "Match found!";
        Popup.messageText.text = "4";
        yield return new WaitForSeconds(1f);
        Popup.messageText.text = "3";
        yield return new WaitForSeconds(1f);
        Popup.messageText.text = "2";
        yield return new WaitForSeconds(1f);
        Popup.messageText.text = "1";
        yield return new WaitForSeconds(1f);
        Popup.messageText.text = "0";
        yield return new WaitForSeconds(1f);

        if (Popup.messageText.text == "0")
        {
            SceneHandler.nextScene();
        }
    }


}
