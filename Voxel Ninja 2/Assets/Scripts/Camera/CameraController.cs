using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float vSpeed;
    [SerializeField] private float changePerSecond;
    [SerializeField] private float distanceToLose;
    [SerializeField] private GameOver gameOver;

    private void Update()
    {
        MoveCamera();
        vSpeed += changePerSecond * Time.deltaTime;
        if (transform.position.y - player.transform.position.y > distanceToLose && player.transform.position.y < transform.position.y)
        {
            gameOver.distance = player.transform.position.y;
            gameOver.Defeat();
        }
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
