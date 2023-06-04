using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    //Движение
    private float moveInput;
    [HideInInspector] public Vector3 direction;

    //Поворот
    [HideInInspector] public Quaternion rotation;
    private float rotationAngle;

    //Прыжок
    [HideInInspector] public bool jumpPressed;

    //Рывок
    [HideInInspector] public bool dashPressed;

    private void Update()
    {
        GetMoveInput();
        GetRotation();
        GetJumpInput();
        GetDashInput();
    }

    private void GetMoveInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        direction = new Vector3(moveInput, 0f, 0f);
    }

    private void GetRotation()
    {
        if (moveInput >= 0)
        {
            rotationAngle = 90;
        }
        else
        {
            rotationAngle = -90;
        }
        rotation = Quaternion.Euler(0f, rotationAngle, 0f);
    }

    private void GetJumpInput()
    {
        jumpPressed = Input.GetButtonDown("Jump");
    }

    private void GetDashInput()
    {
        dashPressed = Input.GetKeyDown(KeyCode.LeftShift);
    }
}
