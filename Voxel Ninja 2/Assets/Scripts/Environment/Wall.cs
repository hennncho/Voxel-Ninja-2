using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Chunk
{
    [SerializeField] private Mesh[] wallMeshes;

    private void Start()
    {
        foreach (var mesh in GetComponentsInChildren<MeshFilter>())
        {
            mesh.sharedMesh = wallMeshes[Random.Range(0, wallMeshes.Length)];
        }
    }
}
