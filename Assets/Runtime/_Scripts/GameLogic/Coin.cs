using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinManager.instance.gainCoin();
            HealthManager.instance.Heal();
            Destroy(gameObject);
        }
    }
}
