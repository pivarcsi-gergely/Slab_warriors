using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenWebsite()
    {
        Application.OpenURL("https://github.com/pivarcsi-gergely/slabackend");
    }
}
