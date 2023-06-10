using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    public void Drop()
    {
        Instantiate(items[Random.Range(0, items.Length)], transform.position, Quaternion.identity);
    }
}
