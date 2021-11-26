using System;
using System.Collections;
using System.Collections.Generic;
using _Runtime.GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Singleton that manages dialog window
// Handles stocking one dialog's sentences

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    private Queue<string> sentences;

    private bool busy = false;

    public bool isBusy => busy;
    
    public GameObject DialogPanel;
    public GameObject ChoicePanel;
    public TextMeshProUGUI dialogUIBox;
    
    public GameObject yesButton, continueButton;
    
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
        PlayerManager.instance.SetMovement(false);
        
        DialogPanel.SetActive(true);
        foreach (var sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        EventSystem.current.SetSelectedGameObject(continueButton);
        DisplayNext();
    }

    public void DisplayNext()
    {
        if (sentences.Count <= 0)
        {
            EndDialog();
        }

        if (sentences.Count == 1)
        {
            // enable choice
            continueButton.SetActive(false);
            ChoicePanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(yesButton);
        }

        var sentence = sentences.Dequeue();
        dialogUIBox.text = sentence;
    }
    
    public void EndDialog()
    {
        busy = false;
        Debug.Log("It is done");
        DialogPanel.SetActive(false);
        PlayerManager.instance.SetMovement(true);

    }
}
