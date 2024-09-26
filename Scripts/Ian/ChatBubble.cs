using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image bg;
    private Color defaultColor;

    public AudioSource talkSound;

    private void Awake()
    {
        defaultColor = bg.color;
    }

    public void setText(string text)
    {
        StartCoroutine(typewriter(text)); 
    }

    public void setPastBubble()
    {
        Color color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a - 0.2f);
        setBgColor(color);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    void setBgColor(Color color)
    {
        bg.color = color;
        text.color = new Color(text.color.r, text.color.g, text.color.b, color.a);
    }

    public void setDefaultColor(Color color)
    {
        defaultColor = new Color(color.r,color.g,color.b, defaultColor.a);
        bg.color = defaultColor;
    }

    IEnumerator typewriter(string txt)
    {
        text.text = "";
        float basePitch = 1.0f;  // Base pitch for the sound effect

        foreach (char c in txt)
        {
            // Add each character to the text
            text.text += c;

            // Play sound effect with varying pitch based on character
            if (char.IsLetter(c)) // Only change pitch for letters
            {
                talkSound.pitch = basePitch + Random.Range(-0.1f, 0.1f); // Random variation in pitch
                talkSound.PlayOneShot(talkSound.clip);
            }

            // Adjust the delay for punctuation marks
            if (c == '.' || c == ',' || c == '!' || c == '?')
                yield return new WaitForSeconds(0.4f);  // Longer pause for punctuation
            else
                yield return new WaitForSeconds(0.05f); // Shorter pause for normal characters
        }
    }

}
