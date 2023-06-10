using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{    
    private ItemDrop itemDrop;
    [SerializeField] private float timeToDestroy;    

    private void Awake()
    {        
        itemDrop = GetComponent<ItemDrop>();        
    }   

    public void Die()
    {        
        itemDrop.Drop();
        Destroy(gameObject, timeToDestroy);        
    }
}
