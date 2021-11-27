using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BooBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;


    [SerializeField] private GameObject BoosPath;
    private Queue<Vector3> Path;

    private int currentIndex = 0;

    private bool RaceStarted
    {
        get;
        set;
    }

    private void Start()
    {

        Path = new Queue<Vector3>();
        agent.stoppingDistance = 0.5f;

        var children = BoosPath.GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            var path = children[i].position;
            Debug.Log(path);
            Path.Enqueue(path);
        }

        Path.Dequeue();
    }

    private void Update()
    {
        if (!RaceStarted) return;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (Path.Count <= 0)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.SetDestination(Path.Dequeue());
            }
        }
    }

    public void StartRace()
    {
        agent.SetDestination(Path.Dequeue());
        RaceStarted = true;
    }
    
    
}
