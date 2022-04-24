using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FighterManager : MonoBehaviour
{
    [SerializeField] ApiController controller;
    [SerializeField] TMP_Dropdown fighterDropdown;
    public List<Fighter> fightersList = new List<Fighter>();
    Fighter selectedFighter;
    public TextMeshPro fighterName, details, attack, hp;
    public GameObject fighterImage;
    public Material[] fighterMaterials;


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
        selectedFighter = fightersList[0];
    }

    public void SaveFighter(int FighterIndex)
    {
        selectedFighter = fightersList[FighterIndex];
        Debug.Log(selectedFighter.name);
    }

    public void FillFighterSlot()
    {
        fighterName.text = selectedFighter.name;
        details.text = selectedFighter.details;
        hp.text = selectedFighter.hp.ToString();
        attack.text = selectedFighter.attack.ToString();
        fighterImage.GetComponent<Renderer>().material = fighterMaterials[selectedFighter.id-1];
}
}
