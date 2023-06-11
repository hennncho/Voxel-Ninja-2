using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int damage;
    [SerializeField] private float timeToDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {           
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;            
        }
        Destroy(gameObject, timeToDestroy);
    }
}
