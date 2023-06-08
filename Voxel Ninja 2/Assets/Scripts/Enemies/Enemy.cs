using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum EnemyState { Patrolling, Chasing, Attacking }
    private EnemyState currentState;
    private EnemyMovement movementController;
    private EnemyAttack attackController;

    private void Awake()
    {
        movementController = GetComponent<EnemyMovement>();
        attackController = GetComponent<EnemyAttack>();
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
        if (!attackController.playerInSightRange && !attackController.playerInAttackRange) currentState = EnemyState.Patrolling;
        if (attackController.playerInSightRange && !attackController.playerInAttackRange) currentState = EnemyState.Chasing;
        if (attackController.playerInSightRange && attackController.playerInAttackRange) currentState = EnemyState.Attacking;
    }
}
