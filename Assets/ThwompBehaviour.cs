using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompBehaviour : MonoBehaviour
{
    public Animator anim;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Crush");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Crush");
        }
    }
}
