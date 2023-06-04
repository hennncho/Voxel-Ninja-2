using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    //Компоненты
    private PlayerInputController input;
    private Rigidbody rb;
    private CapsuleCollider col;

    //Движение
    [SerializeField] private float moveSpeed;    

    //Прыжок
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float distanceToGround;
    [SerializeField] private LayerMask groundLayer;
    private float jumpCount;

    //Кувырок
    [SerializeField] private float rollTime;
    [SerializeField] private float rollSpeed;    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputController>();
        col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Jump();
        Roll();
    }

    private void FixedUpdate()
    {
        if (input.direction.magnitude > 0f)
        {
            Move();
            Rotate();
        }        
    }

    private void Move()
    {
        rb.MovePosition(transform.position + input.direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        rb.MoveRotation(input.rotation);
    }

    private void Jump()
    {
        if (CheckIfGrounded()) jumpCount = 0;

        if (input.jumpPressed && jumpCount < 1)
        {            
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private bool CheckIfGrounded()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x,
                                col.bounds.min.y, col.bounds.center.z);

        bool isGrounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom,
            distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return isGrounded;
    }

    private void Roll()
    {        
           
    }
}
