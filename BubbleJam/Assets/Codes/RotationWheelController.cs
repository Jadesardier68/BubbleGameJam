using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWheelController : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform baseObject;

    [SerializeField] PlayerController playerController;
    Rigidbody2D rb;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.RotateAround(baseObject.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player")) 
        {
            playerController.gameObject.transform.SetParent(gameObject.transform);
            playerController.isOnPlatform = true;
            playerController.platformRB = rb;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player")) 
        {
            playerController.gameObject.transform.SetParent(null);
            playerController.isOnPlatform = false;
        }
    }
}
