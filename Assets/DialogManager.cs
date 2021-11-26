using System;
using System.Collections;
using System.Collections.Generic;
using _Runtime.GameLogic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    private Queue<string> sentences;

    private bool busy = false;

    public GameObject DialogPanel;
    public TextMeshProUGUI dialogUIBox;

    private void Start()
    {
        if (instance == null)
            instance = this;
        sentences = new Queue<string>();

    }

    public void StartDialog(Dialog dialog)
    {
        if(busy) return;
        busy = true;
        
        DialogPanel.SetActive(true);
        foreach (var sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (sentences.Count <= 0)
        {
            EndDialog();
        }

        if (sentences.Count == 1)
        {
            // enable choice
        }

        var sentence = sentences.Dequeue();
        dialogUIBox.text = sentence;
    }

    private void EndDialog()
    {
        busy = false;
        Debug.Log("It is done");
    }
}
