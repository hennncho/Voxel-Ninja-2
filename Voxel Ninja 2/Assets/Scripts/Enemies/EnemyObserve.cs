using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserve : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float verticalRange;
    [HideInInspector] public bool playerInSightRange;
    [HideInInspector] public bool playerInAttackRange;
   
    private void Update()
    {
        CheckPlayerVisibility();
    }

    private void CheckPlayerVisibility()
    {
        playerInSightRange = Physics.CheckBox(transform.position, new Vector2(sightRange, verticalRange), Quaternion.identity, playerLayer);
        playerInAttackRange = Physics.CheckBox(transform.position, new Vector2(attackRange, verticalRange), Quaternion.identity, playerLayer);
    }

    
}
