using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;
using UnityEngine.UI;
using TMPro;

public class SimpleChat : MonoBehaviour
{
    public LLM llm;
    
    public TMP_InputField input;
    public TextMeshProUGUI botResponse;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void enterInput(string text)
    {
        Debug.Log("Sending input...");
        llm.Chat(input.text, handleReply);
        input.text = "";
    }

    void handleReply(string reply)
    {
        botResponse.text = reply;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
