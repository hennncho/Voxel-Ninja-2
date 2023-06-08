using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Range(0, 100)][SerializeField] private int chanceToSpawn;
    [SerializeField] private Enemy[] enemies;

    public void SpawnEnemy(Transform spawnPoint, Transform patrolPoint1, Transform patrolPoint2, GameObject parent)
    {
        int random = Random.Range(0, 100);
        if (random <= chanceToSpawn)
        {
            Enemy newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], parent.transform);
            EnemyMovement movement = newEnemy.GetComponent<EnemyMovement>();
            newEnemy.transform.position = spawnPoint.transform.position;
            movement.patrolPoint1 = patrolPoint1;
            movement.patrolPoint2 = patrolPoint2;
        }                
    }
}
