using UnityEngine;

public class DeckSlot : MonoBehaviour
{
    private CardManager cardManager;

    private void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cardManager.OnDeckSlotClicked();
            //cardManager.Invoke("OnDeckSlotClicked", 3.0f);
        }
    }
}
