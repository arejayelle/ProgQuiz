using System;
using System.Collections;
using System.Collections.Generic;
using _Runtime.GameLogic;
using UnityEngine;

// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Class that manages the trigger zone for the dialog window. 
// If player is in the triggerzone, then start the dialog

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;


    private bool playerInZone = false;
    
    private void Update()
    {
        if (playerInZone && !DialogManager.instance.isBusy)
        {
            if (Input.GetButton("Submit"))
            {
                DialogManager.instance.StartDialog(dialog);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
    
}
