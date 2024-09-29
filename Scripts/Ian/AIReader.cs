using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;
using TMPro;
using UnityEngine.UI;

public class AIReader : MonoBehaviour
{
    public static AIReader instance;

    private AITraits ai;
    public LLM llmCharacter;

    public Transform chatHolder;

    public GameObject chatBubblePrefab;
    private List<ChatBubble> chatBubbles = new List<ChatBubble>();
    private ChatBubble currBubble;

    public int feelingsGoal = 15;
    public int feelings;
    public Slider feelingSlider;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        effectSlider(feelings);
    }

    public void setAI(AITraits ai)
    {
        this.ai = ai;
        llmCharacter = ai.llm;
    }

    public AITraits getAI()
    {
        return ai;
    }

    public void sendMessage(string message)
    {
        GameObject chat = Instantiate(chatBubblePrefab, chatHolder.position, Quaternion.identity);
        chat.transform.parent = chatHolder;
        chat.transform.localScale = new Vector3(0.178227f, 0.178227f, 0.178227f);
        currBubble = chat.GetComponent<ChatBubble>();   

        currBubble.setText("...");
        _ = llmCharacter.Chat(message, SetAIText, AIReplyComplete);

        foreach (ChatBubble chatBubble in chatBubbles)
            chatBubble.setPastBubble(); 
    }

    public void SetAIText(string text)
    {
        Debug.Log("Heard");
        currBubble.setText(text); 
    }

    public void AIReplyComplete()
    {
        chatBubbles.Add(currBubble);
    }

    public void CancelRequests()
    {
        llmCharacter.CancelRequests();
        AIReplyComplete();
    }

   

    bool onValidateWarning = true;
    void OnValidate()
    {
        if (onValidateWarning && !llmCharacter.remote && llmCharacter != null && llmCharacter.model == "")
        {
            Debug.LogWarning($"Please select a model in the {llmCharacter.gameObject.name} GameObject!");
            onValidateWarning = false;
        }
    }

    public void readTone(int feelingsAmt)
    {
        // Define the target value for the slider
        float targetValue = feelingSlider.value;
        feelings += feelingsAmt;

        if (feelingsAmt >= 0)
            currBubble.setDefaultColor(Color.green);
        else
            currBubble.setDefaultColor(Color.red);
       

        effectSlider(targetValue);
    }



    public void effectSlider(float targetValue)
    {
        // Update slider max value if needed
        feelingSlider.maxValue = feelingsGoal;

        // Animate slider with LeanTween
        if (targetValue > feelingSlider.value) // Increasing feelings
        {
            LeanTween.value(gameObject, feelingSlider.value, targetValue, 1f)
                .setOnUpdate((float val) => { feelingSlider.value = val; })
                .setEase(LeanTweenType.easeOutBounce); // Add a bounce effect
            LeanTween.scale(feelingSlider.fillRect.gameObject, Vector3.one * 1.1f, 0.2f)
                .setEasePunch(); // Pulse effect for increasing feelings
        }
        else if (targetValue < feelingSlider.value) // Decreasing feelings
        {
            LeanTween.value(gameObject, feelingSlider.value, targetValue, 1f)
                .setOnUpdate((float val) => { feelingSlider.value = val; })
                .setEase(LeanTweenType.easeInOutQuad); // Smooth easing for decreasing
            LeanTween.moveLocalX(feelingSlider.fillRect.gameObject, 10f, 0.1f)
                .setLoopPingPong(1); // Shake effect for decreasing feelings
        }
    }


}
