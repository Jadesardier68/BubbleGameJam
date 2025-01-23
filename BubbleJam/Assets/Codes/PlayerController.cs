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
    private int bubbleCounter;
    private int bubbleMax;

    public Transform barrel;
    public Transform groundCheck;
    private Rigidbody2D playerBody;
    [SerializeField] LayerMask groundlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        bubbleMax = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        if (Input.GetMouseButtonDown(0) && bubbleCounter < bubbleMax)
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

            bubbleCounter += 1;
            StartCoroutine(ResetBubbleCounter());
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
        } else if (move>0 && !facingRight) {
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

    IEnumerator ResetBubbleCounter() 
    {
        yield return new WaitForSeconds(4f);
        bubbleCounter -= 1;

        if(bubbleCounter < 0 ) 
            bubbleCounter = 0;
    }
}
