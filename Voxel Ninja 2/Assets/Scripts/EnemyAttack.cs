using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{    
    //Компоненты
    [SerializeField] private LayerMask playerLayer;
    private EnemyMovement movementController;

    //Дальность и видимость
    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float verticalRange;
    [HideInInspector] public bool playerInSightRange;
    [HideInInspector] public bool playerInAttackRange;

    //Атака
    [SerializeField] private float attackSpeed;
    private bool readyToAttack = true;

    private void Awake()
    {
        movementController = GetComponent<EnemyMovement>();
    }
    

    private void Update()
    {
        CheckPlayerVisibility();
    }

    private void CheckPlayerVisibility()
    {        
        playerInSightRange = Physics.CheckBox(transform.position, new Vector3(sightRange, verticalRange), Quaternion.identity, playerLayer);
        playerInAttackRange = Physics.CheckBox(transform.position, new Vector3(attackRange, verticalRange), Quaternion.identity, playerLayer);
    }

    public void Attack()
    {
        movementController.agent.SetDestination(transform.position);   
        if (readyToAttack)
        {
            Debug.Log("Na nahui!");
            readyToAttack = false;
            Invoke(nameof(ResetAttack), attackSpeed);
        }
        
    }
    
    private void ResetAttack()
    {
        readyToAttack = true;
    }
}
