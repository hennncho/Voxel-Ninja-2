using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Компоненты
    private PlayerInputController playerInput;    
    private CharacterController character;    

    //Бег
    [SerializeField] private float moveSpeed;    

    //Прыжок
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;    
    [HideInInspector] public float velocity;
    [HideInInspector] public float jumpCount;
    [HideInInspector] public bool isOnGround;
    private Vector3 vDirection;

    //Рывок
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;  
    [HideInInspector] public bool isDashing;
    private float dashStartTime;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInputController>();        
    }    

    private void Update()
    {        
        ApplyGravity();
        Jump();
        Dash();
        isOnGround = character.isGrounded;
        if (playerInput.direction.magnitude >= 0.1f)
        {
            Move();
            Rotate();
        }        
    }    
       
    private void Move()
    {        
        character.Move(playerInput.direction.normalized * moveSpeed * Time.deltaTime);        
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0f, playerInput.direction.x * 90, 0f);
    }
   
    private void ApplyGravity()
    {        
        if (character.isGrounded && velocity < -1)
        {
            velocity = 0;            
        }
        else
        {
            velocity += gravity * Time.deltaTime;            
        }
        vDirection.y = velocity;
        character.Move(vDirection * Time.deltaTime);
    }

    private void Jump()
    {
        if (character.isGrounded)
        {
            jumpCount = 0;
        }

        if (playerInput.JumpButtonPressed() && jumpCount <= 1)
        {
            velocity += jumpForce;
            jumpCount++;
        }
    }

    private void Dash()
    {
        if (playerInput.DashButtonPressed())
        {
            StartCoroutine(activateDash());
        }

        IEnumerator activateDash()
        {
            isDashing = true;
            dashStartTime = Time.time;
            velocity = 0;
            float gravityTemp = gravity;
            gravity = 0;
            while (Time.time < dashStartTime + dashTime)
            {                
                character.Move(playerInput.direction.normalized * dashSpeed * Time.deltaTime);                
                yield return null;
            }
            gravity = gravityTemp;
            isDashing = false;
        }
    }

}
