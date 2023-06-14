using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    private PlayerInputController inputController;
    private Rigidbody rb;
    
    [SerializeField] private Projectile projectile;
    public float maxAmmo;
    [HideInInspector] public float currentAmmo;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform startThrowPoint;    

    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();        
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (inputController.ThrowButtonPressed())
        {
            Throw();
        }        
    }

    private void Throw()
    {
        if (currentAmmo > 0)
        {
            Projectile newProjectile = Instantiate(projectile, startThrowPoint.position, transform.rotation);
            Vector3 forceToAdd = transform.forward * throwForce;
            rb = newProjectile.GetComponent<Rigidbody>();
            rb.AddForce(forceToAdd, ForceMode.Impulse);
            currentAmmo--;
        }        
    }
}