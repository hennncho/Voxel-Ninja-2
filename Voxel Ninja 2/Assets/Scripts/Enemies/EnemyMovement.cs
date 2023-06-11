using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    private Transform player;
    [SerializeField] public Transform patrolPoint1;
    [SerializeField] public Transform patrolPoint2;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;
    private Vector3 currentPoint;    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Ninja").transform;
    }

    private void Start()
    {
        currentPoint = patrolPoint1.position;        
    }    

    public void Patrol()
    {        
        agent.speed = patrolSpeed;
        if (!agent.hasPath)
        {
            currentPoint = currentPoint == patrolPoint1.position ? patrolPoint2.position : patrolPoint1.position;
            agent.SetDestination(currentPoint);
        }
    }

    public void Chase()
    {        
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
    }

    
    public void Stop()
    {
        agent.SetDestination(transform.position);
    }
}
