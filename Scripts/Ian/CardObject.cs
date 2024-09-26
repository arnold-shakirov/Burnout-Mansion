using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardObject : MonoBehaviour
{
    public string cardText; // Placeholder for card class, don't forget it will also hold an integer
    private AITraits ai;
    public TextMeshProUGUI frontText;

    private void Start()
    {
        initializeCard(cardText); // Placeholder, get rid of this start function when ready
    }

    public void initializeCard(string text)
    {
        frontText.text = text;
        cardText = text;
    }

    public void clickCard()
    {
        ai = AIReader.instance.getAI();
        ai.checkResponse(cardText);
        Destroy(gameObject);
    }

}
