using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombombBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator animator; 
    private bool isStopped = false;

    private void Update()
    {
        animator.SetBool("Moving", !agent.isStopped);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(other.gameObject.transform.position);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(other.gameObject.transform.position);
            
        }
    }

    public void Explode()
    {
        // stop moving
        isStopped = true;
        agent.SetDestination(gameObject.transform.position);
        animator.SetTrigger("Explode");
        
    }
    
}
