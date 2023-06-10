using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyDeath enemyDeath;
    private CapsuleCollider col;
    [SerializeField] private int maxHP;
    public int currentHP;
    

    private void Awake()
    {
        enemyDeath = GetComponent<EnemyDeath>();
        col = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        currentHP = maxHP;        
    }

    public void TakeDamage(int damage)
    {
        if (currentHP > 0) currentHP -= damage;
        if (currentHP <= 0)
        {
            col.enabled = false;
            enemyDeath.Die();
        }
    }
}
