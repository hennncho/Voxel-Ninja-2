using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkSpawn : MonoBehaviour
{
    [SerializeField] private Chunk startChunk;
    [SerializeField] private Chunk[] ChunkPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceToSpawn;
    private float distanceToLastChunk;
    private List<Chunk> spawnedChunks = new();    

    private void Start()
    {
        spawnedChunks.Add(startChunk);
        for (int i = 0; i < 3; i++)
        {
            Spawn();
        }        
    }

    private void Update()
    {
        distanceToLastChunk = Vector3.Distance(player.position, spawnedChunks[spawnedChunks.Count - 1].transform.position);
        if (distanceToLastChunk <= distanceToSpawn) Spawn();       
        
        if (spawnedChunks.Count > 7)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private void Spawn()
    {
        Chunk newChank = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChank.transform.position = 
            spawnedChunks[spawnedChunks.Count - 1].end.position - newChank.begin.localPosition;
        spawnedChunks.Add(newChank);        
    }
    
}
