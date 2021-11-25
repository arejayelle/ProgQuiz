using UnityEngine;

namespace _Runtime.Managers
{ 
    // ------------------------------------------------------------------------------
    // Quiz
    // Written by: Jun Loke 40025838
    // For COMP 376 – Fall 2021
    // -----------------------------------------------------------------------------
    //
    // SoundsList singleton to store references to the sound objects
    public class SoundsList
    {
        public static SoundsList instance;
        
        public 
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }
}