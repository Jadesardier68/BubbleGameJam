using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bubblesNormal;
    public GameObject bubblesHot;
    public GameObject bubblesCold;

    public GameObject UINormal;
    public GameObject UIHot;
    public GameObject UICold;
    
    public float speed = 3f;
    public float jumpForce;
    public bool facingRight = true;

    public Transform barrel;
    public Transform groundCheck;
    private Rigidbody2D playerBody;
    public LayerMask groundlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        if (Input.GetMouseButtonDown(0))
        {
            if(UINormal.activeSelf==true)
            {
                InstantiateBubblesNormal();
            }

            if (UIHot.activeSelf == true)
            {
                InstantiateBubblesHot();
            }

            if (UICold.activeSelf == true)
            {
                InstantiateBubblesCold();
            }

        }
    }

    public void InstantiateBubblesNormal()
    {
        Instantiate(bubblesNormal,barrel.position, transform.rotation);
    }

    public void InstantiateBubblesCold()
    {
        Instantiate(bubblesCold,barrel.position, transform.rotation);
    }

    public void InstantiateBubblesHot()
    {
        Instantiate(bubblesHot,barrel.position, transform.rotation);
    }

    public void Movement()
    {

        float move = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(move * speed, playerBody.velocity.y);

        if(move<0 && facingRight)
        {
            Flip();
        }
        else if (move>0 && !facingRight)
        {
            Flip();
        }


        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }
    }

    public bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

         
    private void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0, 180, 0);
    }
}
