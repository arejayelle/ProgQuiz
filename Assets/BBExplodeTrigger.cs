using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBExplodeTrigger : MonoBehaviour
{
    public BombombBehaviour behaviour;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            behaviour.Explode();
        }
    }
}
