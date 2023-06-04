using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    private PlayerInputController playerInput;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        RunAnimation();
        FallAnimation();
        DoubleJumpAnimation();        
    }

    private void RunAnimation()
    {
        animator.SetBool("IsRunning", playerInput.direction.magnitude >= 0.1f);
    }
    
    private void FallAnimation()
    {
        animator.SetBool("IsFalling", !movement.isOnGround && movement.velocity < -5);
    }

    private void DoubleJumpAnimation()
    {
        if (playerInput.JumpButtonPressed() && movement.jumpCount == 1)
        {
            animator.SetTrigger("DoubleJump");            
        }
    }
}
