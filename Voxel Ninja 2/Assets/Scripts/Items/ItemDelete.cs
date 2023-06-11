using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    [SerializeField] private GameObject parent;    

    public void Delete()
    {
        Destroy(parent);
    }
}
