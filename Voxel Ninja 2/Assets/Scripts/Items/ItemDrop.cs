using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int chanceToDrop;
    [SerializeField] private GameObject[] items;

    public void Drop()
    {
        int randomForDrop = Random.Range(0, 100);
        if (randomForDrop <= chanceToDrop)
        {
            Instantiate(items[Random.Range(0, items.Length)], transform.position, Quaternion.identity);
        }
    }
}
