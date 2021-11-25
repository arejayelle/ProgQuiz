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

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
