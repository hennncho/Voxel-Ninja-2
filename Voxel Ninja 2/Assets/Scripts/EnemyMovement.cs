using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    private Transform player;

    [SerializeField] private Transform patrolPoint1;
    [SerializeField] private Transform patrolPoint2;
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
            if (transform.position == patrolPoint1.position) currentPoint = patrolPoint2.position;
            else currentPoint = patrolPoint1.position;
            agent.SetDestination(currentPoint);
        }
        
    }

    public void Chase()
    {        
        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);
    }

    private void Rotate()
    {
        transform.LookAt(agent.destination);
    }
}
