using System;
using System.Collections;
using System.Collections.Generic;
using _Runtime;
using UnityEngine;

public class ThwompButt : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("crush");
            HealthManager.instance.LoseHealth(8);
            PlayerManager.instance.Die(DeathType.Crushed);
        }
    }
}
