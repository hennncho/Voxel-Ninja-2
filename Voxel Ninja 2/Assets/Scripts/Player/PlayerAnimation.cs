using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInputController input;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        RunAnimation();
    }

    private void RunAnimation()
    {
        animator.SetBool("IsRunning", input.direction.magnitude > 0);
    }
}
