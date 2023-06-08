using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    
    private EnemySpawn enemySpawn;

    public Transform enemySpawnPoint;
    public Transform enemyPatrolPoint1;
    public Transform enemyPatrolPoint2;

    private void Awake()
    {
        enemySpawn = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
    }

    private void Start()
    {
        enemySpawn.SpawnEnemy(enemySpawnPoint, enemyPatrolPoint1, enemyPatrolPoint2, gameObject);
    }
}
