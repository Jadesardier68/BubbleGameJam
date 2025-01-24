using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameController gamecontroller;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        gamecontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerFeet"))
        {
            gamecontroller.UpdateCheckPoint(respawnPoint.position);
            spriteRenderer.sprite = active;
        }
    }
}
