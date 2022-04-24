using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] ApiController apiController;
    public List<Card> cardsList = new List<Card>();
    public GameObject[] deckSlots;
    public Material[] materials;
    private TextMeshPro[] cardTexts;
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    private GameObject goCardSlot;
    private GameObject goParent;
    private int index = 0;
    private int PlacedDownCardsThisTurn = 0;

    private Ray ray;
    private RaycastHit hit;
    private GameObject _selected;
    private string SelectableTag = "Selectable";

    private void Awake()
    {
        apiController.CardsGet(cardsList);
        FillCards();
        goCardSlot = GameObject.Find("CardSlotBase");
        goParent = GameObject.Find("CardSlotContainer");
    }

    public void FixedUpdate()
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                _selected = hit.transform.gameObject;
            }
        }
    }

    public void FillCards()
    {
        for (int i = 0; i < cardsList.Count; i++)
        {
            cardTexts = deckSlots[i].GetComponentsInChildren<TextMeshPro>();
            cardTexts[0].text = cardsList[i].name;
            cardTexts[1].text = cardsList[i].details;
            cardTexts[2].text = cardsList[i].hp.ToString();
            cardTexts[3].text = cardsList[i].attack.ToString();
            GameObject cardImage = deckSlots[i].transform.GetChild(0).gameObject;
            cardImage.GetComponent<Renderer>().material = materials[i];
        }
    }

    public void OnDeckSlotClicked()
    {
        if (PlacedDownCardsThisTurn == 3)
        {
            Debug.Log("You cannot place down more cards this turn!");
        }
        else
        {
            if (availableCardSlots[index] == true)
            {
                Debug.Log("Mouse's X index: " + Input.mousePosition.x);
                Debug.Log("Mouse's Y index: " + Input.mousePosition.y);
                Debug.Log(_selected.name);
                if (hit.transform.gameObject.CompareTag(SelectableTag))
                {
                    GameObject go = Instantiate(_selected, cardSlots[index].transform.position, goCardSlot.transform.rotation, goParent.transform);
                    go.name = "CardSlot" + index;
                    availableCardSlots[index] = false;
                    if (index >= 5)
                    {
                        index = 5;
                    }
                    else
                    {
                        index++;
                    }
                }
                else
                {
                    Debug.Log(hit.transform.gameObject.name + " is not the gameobject I want!");
                }    
            }
        }
        if (_selected != null)
        {
            _selected = null;
        }
    }
}
