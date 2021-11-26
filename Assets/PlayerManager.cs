using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        
    }
    #region Animator

    public void animJump(bool jump)
    {
        animator.SetBool("Jump", jump);
    } 
    
    public void animRun(bool run)
    {
        animator.SetBool("Run", run);
    }
    #endregion
}
