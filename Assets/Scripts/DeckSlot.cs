using UnityEngine;

public class DeckSlot : MonoBehaviour
{
    private CardManager cardManager;

    private void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
    }

    private void OnMouseDown()
    {
        cardManager.Invoke("Update", 1.0f);
    }
}
