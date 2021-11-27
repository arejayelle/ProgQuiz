using System;
using _Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// ------------------------------------------------------------------------------
// Quiz
// Written by: Jun Loke 40025838
// For COMP 376 – Fall 2021
// -----------------------------------------------------------------------------
//
// Manage the player


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Animator anim;

    private void Start()
    {
        if (instance == null)
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

        SceneManager.LoadScene("LoseScreen");

    }

    private void Despawn()
    {
        Destroy(gameObject);
    }

    #region movement

    [SerializeField] private PlayerMovement movementScript;

    public void SetMovement(bool enable)
    {
        movementScript.enabled = enable;
    }

    public void SpeedBoost()
    {
        movementScript.Boost();
    }

    #endregion

    #region Animator

    public void animJump(bool jump)
    {
        anim.SetBool("Jump", jump);
    }

    public void animRun(bool run)
    {
        anim.SetBool("Run", run);
    }

    #endregion
}