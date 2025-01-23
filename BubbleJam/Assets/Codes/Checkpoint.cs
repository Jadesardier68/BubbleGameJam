using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameController gamecontroller;
    public Transform respawnPoint;

    private void Awake()
    {
        gamecontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gamecontroller.UpdateCheckPoint(respawnPoint.position);
        }
    }
}
