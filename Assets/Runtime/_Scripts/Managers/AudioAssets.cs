using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Audio Manager singleton to handle audio

public class AudioAssets : MonoBehaviour
{
    private static AudioAssets instance;
    
    public static AudioAssets i
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        if (instance == null)
            instance = this;
        
        coinPlink.setSource(gameObject.AddComponent<AudioSource>());
        marioYa.setSource(gameObject.AddComponent<AudioSource>());
    }
    

    public Sound coinPlink;
    public Sound marioYa;

}
