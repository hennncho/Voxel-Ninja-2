using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState { Patrolling, Chasing, Attacking }
    private EnemyState currentState;
    private EnemyMovement movementController;
    private EnemyMeleeAttack attackController;
    private EnemyObserve observer;

    private void Awake()
    {
        movementController = GetComponent<EnemyMovement>();
        attackController = GetComponent<EnemyMeleeAttack>();
        observer = GetComponent<EnemyObserve>();
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

            default:
                break;
        }
    }

    private void ChangeState()
    {
        if (!observer.playerInSightRange && !observer.playerInAttackRange) currentState = EnemyState.Patrolling;
        if (observer.playerInSightRange && !observer.playerInAttackRange) currentState = EnemyState.Chasing;
        if (observer.playerInSightRange && observer.playerInAttackRange) currentState = EnemyState.Attacking;
    }
}
