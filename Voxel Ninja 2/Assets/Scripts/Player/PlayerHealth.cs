using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{    
    public float maxHP;
    [HideInInspector] public float currentHP;
    private BloodEffect blood;

    private void Awake()
    {
        blood = GetComponent<BloodEffect>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (currentHP > 0) currentHP -= damage;
        blood.PlayEffect();
    }
}
