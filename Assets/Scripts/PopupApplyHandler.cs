using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupApplyHandler : MonoBehaviour
{
    [SerializeField] private Popup PopupGraphics;
    [SerializeField] private Popup PopupVolume;

    // Start is called before the first frame update
    void Start()
    {
        PopupVolume.titleText.text = "Apply settings?";
        PopupVolume.messageText.text = "Yes or no?";

        PopupGraphics.titleText.text = "Apply settings?";
        PopupGraphics.messageText.text = "Yes or no?";
    }
}