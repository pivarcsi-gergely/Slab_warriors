using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FighterManager : MonoBehaviour
{
    [SerializeField] ApiController controller;
    [SerializeField] TMP_Dropdown fighterDropdown;
    public List<Fighter> fightersList = new List<Fighter>();
    Fighter selectedFighter;

    void Awake()
    {
        controller.FightersGet(fightersList);
    }

    public void FillDropdown()
    {
        fighterDropdown.ClearOptions();
        List<string> fighterString = new List<string>();
        for (int i = 0; i < fightersList.Count; i++)
        {
            fighterString.Add(fightersList[i].name);
        }
        fighterDropdown.AddOptions(fighterString);
        fighterDropdown.RefreshShownValue();
    }

    public void saveFighter(int FighterIndex)
    {
        selectedFighter = fightersList[FighterIndex];
        Debug.Log(selectedFighter.name);
    }
}
