using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;

public class AITraits : MonoBehaviour
{
    public LLM llm;
    public List<string> likes = new List<string>();

    private void Start()
    {
        appear(); // Just doing this until gameplay is set up
    }

    // This is where it sets up the conversation
    public void appear()
    {
        AIReader.instance.setAI(this);
        CardManager.instance.setupCards();
    }

    public void checkResponse(string card /*placeholder*/)
    {
        card.ToLower();
        foreach (string item in likes)
        {
            item.ToLower();
        }

        int amount = 0;
        string prefix = "(Neutral)";
        if (likes.Contains(card))
        {
            prefix = "(Agree)";
            amount = 1; // Placeholder
        }
        else
        {
            prefix = "(Disagree)";
            amount = -1;
        }

        AIReader.instance.sendMessage($"{prefix} {card}");
        AIReader.instance.readTone(amount); // Placeholder numbers
    }
}
