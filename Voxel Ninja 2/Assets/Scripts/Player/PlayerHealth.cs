using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{    
    [SerializeField] private int maxHP;
    public int currentHP;    

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (currentHP > 0) currentHP -= damage;
        
    }
}
