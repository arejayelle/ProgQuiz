using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombombBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator animator; 

    private void Start()
    {
        agent.stoppingDistance = 0.5f;
    }

    private void Update()
    {
        var distance = (agent.destination - agent.transform.position).magnitude;
        
        animator.SetBool("Moving", (distance > agent.stoppingDistance));
        
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
        agent.isStopped = true;
        animator.SetTrigger("Explode");
        HealthManager.instance.LoseHealth(3);
        Destroy(gameObject);
    }
    
}
