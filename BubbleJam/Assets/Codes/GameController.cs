using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkPointPos;
     [SerializeField] SpriteRenderer spriteRenderer;


    private void Start()
    {
        checkPointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathLimit"))
        {
            Die();
        }
    }

    public void UpdateCheckPoint(Vector2 Pos)
    {
        checkPointPos = Pos;
    }

    void Die()
    {
        StartCoroutine(Respawn(0.2f));
    }
    
    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        spriteRenderer.enabled = true;
    }
}
