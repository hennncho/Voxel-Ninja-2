using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    private PlayerInputController playerInput;

    [Header("Параметры атаки")]
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    private bool alreadyAttacked;
    
    [Header("Зона атаки")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private float distance;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        if (playerInput.AttackButtonPressed() && !alreadyAttacked)
        {
            GameObject enemy = GetTarget();
            if (enemy != null) Debug.Log(enemy.name);
            if (enemy != null) Attack(enemy);
            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    private void Attack(GameObject target)
    {        
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage(damage);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private GameObject GetTarget()
    {
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.localPosition,
                                     size / 2,
                                     transform.forward,
                                     out hit,
                                     Quaternion.identity,
                                     distance,
                                     enemyLayer);
        if (isHit)
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.localPosition + center, size);
    }
}
