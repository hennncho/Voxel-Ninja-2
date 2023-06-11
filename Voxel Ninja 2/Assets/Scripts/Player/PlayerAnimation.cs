using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInputController playerInput;
    private PlayerMovement movementController;
    private PlayerMeleeAttack attackController;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        movementController = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInputController>();
        attackController = GetComponent<PlayerMeleeAttack>();
    }

    private void Update()
    {
        RunAnimation();
        FallAnimation();
        DoubleJumpAnimation();
        AttackAnimation();
    }

    private void RunAnimation()
    {
        animator.SetBool("IsRunning", playerInput.direction.magnitude >= 0.1f);
    }
    
    private void FallAnimation()
    {
        animator.SetBool("IsFalling", !movementController.isOnGround && movementController.velocity < -5);
    }

    private void DoubleJumpAnimation()
    {
        if (playerInput.JumpButtonPressed() && movementController.jumpCount == 2)
        {
            animator.SetTrigger("DoubleJump");            
        }
    }

    private void AttackAnimation()
    {
        if (playerInput.AttackButtonPressed() && !attackController.alreadyAttacked)
        {
            animator.SetTrigger("MeleeAttack");
        }
    }
}
