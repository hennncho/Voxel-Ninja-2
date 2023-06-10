using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 distanceToPlayer;

    private void Start()
    {
        distanceToPlayer = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + distanceToPlayer;        
    }
}
