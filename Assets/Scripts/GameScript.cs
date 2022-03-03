using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown DDDecks = null;

    // Start is called before the first frame update
    void Start()
    {
        DDDecks.ClearOptions();
        List<string> deckOptions = new List<string>();
        deckOptions.Add("Starter Deck");
        DDDecks.AddOptions(deckOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
