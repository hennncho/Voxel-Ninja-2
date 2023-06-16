using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{    
    private ItemDrop itemDrop;
    [SerializeField] private float timeToDestroy;
    private GameOver gameOver;

    private void Awake()
    {        
        itemDrop = GetComponent<ItemDrop>();
        gameOver = FindAnyObjectByType<GameOver>();
    }   

    public void Die()
    {
        gameOver.killCount++;
        itemDrop.Drop();
        Destroy(gameObject, timeToDestroy);        
    }
}
