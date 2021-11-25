using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Singleton to manage coins and coin display

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    private static int MaxHealth = 8;
    
    private float health = MaxHealth;
    
    // Get reference to UI component for updating
    public Image HealthDisplayUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // set up singleton
        if (instance == null)
            instance = this;
        
        UpdateDisplay();
    }

    public void Heal()
    {
        if(health< MaxHealth)
            health += 1;
    }
    public void LoseHealth()
    {
        health -= 1;
    }

    private void UpdateDisplay()
    {
        HealthDisplayUI.fillAmount = health / MaxHealth;
        switch (health)
        {
            case 8:
            case 7:
                HealthDisplayUI.color = Color.blue;
                break;
            case 6:
            case 5:
                HealthDisplayUI.color = Color.green;
                break;
            case 4:
            case 3:
                HealthDisplayUI.color = Color.yellow;
                break;
            case 2:
            case 1:
                HealthDisplayUI.color = Color.red;
                break;
            default:
                break;
        }


    }
}