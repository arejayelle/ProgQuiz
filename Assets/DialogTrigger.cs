using System;
using System.Collections;
using System.Collections.Generic;
using _Runtime.GameLogic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Input.GetKey("P"))
                TriggerDialog();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialog();
        }
    }

    public void TriggerDialog()
    {
        DialogManager.instance.StartDialog(dialog);
    }
}
