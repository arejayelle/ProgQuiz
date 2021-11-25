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
    public AudioClip clip;
    
    [Range(0f,1f)]
    public float volume = 1;
    [Range(0.1f, 3f)]
    public float pitch = 1;

    [HideInInspector] 
    public AudioSource source;

    public void Play()
    {
        source.Play();
    }

    public void setSource(AudioSource audioSource)
    {
        source = audioSource;
        
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
    }
}
