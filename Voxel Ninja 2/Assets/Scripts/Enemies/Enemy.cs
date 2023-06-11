using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState { Patrolling, Chasing, Attacking, Dead }
    private EnemyState currentState;
    private EnemyMovement movementController;
    private EnemyMeleeAttack attackController;
    private EnemyObserve observer;
    private EnemyHealth health;

    private void Awake()
    {
        movementController = GetComponent<EnemyMovement>();
        attackController = GetComponent<EnemyMeleeAttack>();
        observer = GetComponent<EnemyObserve>();
        health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        ChangeState();
        switch (currentState)
        {
            case EnemyState.Patrolling:
                movementController.Patrol(); 
                break;

            case EnemyState.Chasing:                
                movementController.Chase();
                break;

            case EnemyState.Attacking:
                attackController.Attack();
                break;

            case EnemyState.Dead:
                movementController.Stop();
                break;

            default:
                break;
        }
    }

    private void ChangeState()
    {
        if (health.isAlive)
        {
            if (!observer.playerInSightRange && !observer.playerInAttackRange) currentState = EnemyState.Patrolling;
            if (observer.playerInSightRange && !observer.playerInAttackRange) currentState = EnemyState.Chasing;
            if (observer.playerInSightRange && observer.playerInAttackRange) currentState = EnemyState.Attacking;
        }
        else currentState = EnemyState.Dead;
    }
}
