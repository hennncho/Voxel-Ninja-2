using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float vSpeed;

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {        
        transform.Translate(Vector3.up * vSpeed * Time.deltaTime);
        if (player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
