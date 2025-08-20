using System.Collections;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class Text : MonoBehaviour
{
    public TextMeshProUGUI logText;
    public float typingInterval = 0.09f;

    private string fullText;
    void Start()
    {
        fullText = logText.text;
        logText.text = "";//saisyo hihyouji
        
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            logText.text += c;
            yield return new WaitForSeconds(typingInterval);
        }
    }
}
