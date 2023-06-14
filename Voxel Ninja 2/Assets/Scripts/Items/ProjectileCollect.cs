using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollect : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRangeAttack playerRangeAtack = other.GetComponent<PlayerRangeAttack>();
            if (playerRangeAtack.currentAmmo < playerRangeAtack.maxAmmo)
            {
                playerRangeAtack.currentAmmo++;
                animator.SetTrigger("Collected");
            }
        }
    }
}
