using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Lose screen allows you to reload the main screen
// Not the most efficient but I'm tired
public class LoseScreen : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("BombombBattlefield");
    }
}
