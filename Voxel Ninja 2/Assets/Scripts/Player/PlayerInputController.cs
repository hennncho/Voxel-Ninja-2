using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{    
    private float hInput;    
    [HideInInspector] public Vector3 direction;    

    private void Update()
    {        
        hInput = Input.GetAxisRaw("Horizontal");        
        direction = new Vector3(hInput, 0f, 0f).normalized;         
    }

    public bool JumpButtonPressed()
    {
        bool pressed = Input.GetButtonDown("Jump");
        return pressed;
    }

    public bool DashButtonPressed()
    {
        bool pressed = Input.GetKeyDown(KeyCode.LeftShift);
        return pressed;
    }

    public bool AttackButtonPressed()
    {
        bool pressed = Input.GetMouseButtonDown(0);
        return pressed;
    }

    public bool ThrowButtonPressed()
    {
        bool pressed = Input.GetKeyDown(KeyCode.F);
        return pressed;
    }
}
