using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    
    private void Start()
    {
        if (instance == null)
            instance = this;

    }
    public PlayerMovement movementScript;

    public void SetMovement(bool enable)
    {
        movementScript.enabled = enable;
    }
}
