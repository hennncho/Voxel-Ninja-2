using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyDeath enemyDeath;
    private CapsuleCollider col;
    [SerializeField] private int maxHP;
    public int currentHP;
    [HideInInspector] public bool isAlive;
    private BloodEffect blood;

    private void Awake()
    {
        enemyDeath = GetComponent<EnemyDeath>();
        col = GetComponent<CapsuleCollider>();
        blood = GetComponent<BloodEffect>();
    }

    private void Start()
    {
        isAlive = true;
        currentHP = maxHP;        
    }

    public void TakeDamage(int damage)
    {
        if (currentHP > 0) currentHP -= damage;
        if (currentHP <= 0)
        {
            isAlive = false;
            col.enabled = false;
            enemyDeath.Die();
        }
        blood.PlayEffect();
    }
}
