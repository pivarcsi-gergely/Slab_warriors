using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupWindow : MonoBehaviour
{
    [SerializeField] private MMPopup mMPopup;
    [SerializeField] private Menu_script menu_Script;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDown());

    }

    IEnumerator countDown()
    {
        mMPopup.titleText.text = "Match found!";
        mMPopup.messageText.text = "4";
        yield return new WaitForSeconds(1f);
        mMPopup.messageText.text = "3";
        yield return new WaitForSeconds(1f);
        mMPopup.messageText.text = "2";
        yield return new WaitForSeconds(1f);
        mMPopup.messageText.text = "1";
        yield return new WaitForSeconds(1f);
        mMPopup.messageText.text = "0";
        yield return new WaitForSeconds(1f);

        if (mMPopup.messageText.text == "0")
        {
            menu_Script.nextScene();
        }
    }
}
