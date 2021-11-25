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
// Class to represent a sound clip
[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    
    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
}
