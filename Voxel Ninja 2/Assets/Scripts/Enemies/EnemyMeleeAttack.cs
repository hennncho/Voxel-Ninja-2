using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMeleeAttack : MonoBehaviour
{
    private EnemyMovement movementController;

    [Header("Параметры атаки")]    
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    private bool alreadyAttacked;

    [Header("Зона атаки")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private float distance;

    private void Awake()
    {
        movementController = GetComponent<EnemyMovement>();
    }    

    public void Attack()
    {
        if (!alreadyAttacked)
        {
            movementController.agent.destination = transform.position;
            GameObject player = GetTarget();
            if (player != null)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damage);
            }            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
        }
        
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private GameObject GetTarget()
    {
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.position,
                                     size / 2,
                                     transform.forward,
                                     out hit,
                                     Quaternion.identity,
                                     distance,
                                     playerLayer);
        if (isHit)
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + center, size);
    }    
}
