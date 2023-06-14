using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMesh : MonoBehaviour
{
    [Range(0, 100)] [SerializeField] private int chanceToChange;
    [Range(0, 100)] [SerializeField] private int chanceToRotate;
    [SerializeField] private Mesh defaultMesh;
    [SerializeField] private Mesh[] meshVariants;   
    [SerializeField] private Vector3 rotation;
    
    private void Start()
    {
        ChangeMeshForRandom();
    }

    private void ChangeMeshForRandom()
    {        
        foreach (var mesh in GetComponentsInChildren<MeshFilter>())
        {
            int randomForChange = Random.Range(1, 101);
            if (randomForChange <= chanceToChange)
            {
                mesh.sharedMesh = meshVariants[Random.Range(0, meshVariants.Length)];
                int randomForRotate = Random.Range(1, 101);
                if (randomForRotate <= chanceToRotate)
                {
                    mesh.transform.localScale = rotation;
                }
            }
        }
    }
}
