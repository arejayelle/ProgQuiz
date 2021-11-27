using System.Collections;
using System.Collections.Generic;
using _Runtime.Managers;
using TMPro;
using UnityEngine;

// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Singleton to manage coins and coin display

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int numCoins = 0;
    
    // Get reference to UI component for updating
    public TextMeshProUGUI coinUIText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // set up singleton
        if (instance == null)
            instance = this;
        
        coinUIText.text = $"x {numCoins}";
    }

    public void gainCoin()
    {
        numCoins++;
        coinUIText.text = $"x {numCoins}";
        AudioAssets.i.coinPlink.Play();
        PlayerManager.instance.SpeedBoost();
    }
}
