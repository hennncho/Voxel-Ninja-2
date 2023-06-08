using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform begin;
    public Transform end;

    [Header("Пол")]    
    [SerializeField] private Transform floorPoint;
    [SerializeField] private Floor[] floorPrefabs;

    [Header("Стены")]
    [SerializeField] private Transform wallPoint;
    [SerializeField] private Wall[] wallPrefabs;

    private void Start()
    {
        SpawnFloor();
        SpawnWall();
    }

    private void SpawnFloor()
    {
        Floor newFloor = Instantiate(floorPrefabs[Random.Range(0, floorPrefabs.Length)], floorPoint);
    }

    private void SpawnWall()
    {
        Wall newWall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)], wallPoint);
    }
}
