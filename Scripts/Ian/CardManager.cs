using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public GameObject cardPrefab;
    // Set up inventory var 

    private void Awake()
    {
        instance = this;
    }

    public void setupCards()
    {
        // Grab from inventory...
        // List of cards

        // Instantiate those into CardObjects
        // cardPrefab.GetComponent<CardObject>().initializeCard(card);
    }
}
