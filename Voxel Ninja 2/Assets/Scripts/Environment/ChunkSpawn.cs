using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawn : MonoBehaviour
{
    [SerializeField] private Chunk chunk;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float maxAmount;
    [SerializeField] private float distanceToSpawn;
    [SerializeField] private Transform player;        
    private float distanceToLastChunk;
    private List<Chunk> spawnedChunks = new();

    private void Start()
    {
        
        for (int i = 0; i < 20; i++)
        {
            SpawnChunk();
        }
    }

    private void Update()
    {
        distanceToLastChunk = Vector3.Distance(player.position, spawnedChunks[spawnedChunks.Count - 1].transform.position);
        if (distanceToLastChunk <= distanceToSpawn) SpawnChunk();
        
        if (spawnedChunks.Count > maxAmount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(chunk);
        if (spawnedChunks.Count == 0)
        {
            newChunk.transform.position = startPoint.position - newChunk.begin.localPosition;
        }
        else
        {
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].end.position - newChunk.begin.localPosition;
        }
        spawnedChunks.Add(newChunk);        
    }
}
