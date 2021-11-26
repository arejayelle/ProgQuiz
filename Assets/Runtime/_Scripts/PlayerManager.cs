using System;
using UnityEngine;

// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Manage the player

namespace _Runtime
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Animator anim;
        private void Start()
        {
            if(instance == null)
                instance = this;
        }

        public void Die(DeathType deathType)
        {
            switch (deathType)
            {
                case DeathType.Crushed:
                    anim.SetTrigger("Squish");
                    break;
                default: 
                    break;
            }
        }
    }
}