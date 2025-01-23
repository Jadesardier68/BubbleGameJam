using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float lifeSpanMax = 3f; //points de vie max
    public float lifeSpanLeft; //points de vie restants
    public float slideDuration;
    public float slideDistanceUp;
    public float slideDurationUp;
    public float speed = 2;

    public float lifeTimeMax = 10f;
    public float timer;
    public float timerBubble;
    public float elapsedTime = 0;

    public bool isPaused = false;
    public PlayerController playercontroller;
    private Animator bubbleAnimator;
    public Rigidbody2D bubbleBody;
    

    // Start is called before the first frame update
    void Start()
    {
        if (playercontroller == null)
        {
            playercontroller = FindObjectOfType<PlayerController>();
        }
        bubbleAnimator.GetComponent<Animator>();
        lifeSpanLeft = lifeSpanMax;
        BubbleShooting();
        StartCoroutine(ScaleThenStartTimer());

    }

    // Update is called once per frame
    void Update()
    {
        movementController();

        if (!isPaused)
        {
            timer += Time.deltaTime;
            if (timer >= lifeTimeMax)
            {
                //Destroy(gameObject);
                StartCoroutine(BubblePop());
            }
        }
    }

    public void BubbleShooting()
    {
        bubbleBody.velocity = transform.right * speed;
    }

    public void movementController() 
    {
        timerBubble += Time.deltaTime;
        if(timerBubble >= slideDuration) 
        {
            bubbleBody.velocity = new Vector2(0,0);
        }
    }


    IEnumerator ScaleThenStartTimer()
    {
        Vector3 startScale = Vector3.zero;
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);

        elapsedTime = 0;

        if (playercontroller.facingRight == true)
        {
            while (elapsedTime < slideDuration)
            {
                // transform.position = Vector3.Lerp(startPosition, targetPositionRight, elapsedTime / slideDuration);
                transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / slideDuration);

                elapsedTime += Time.deltaTime;
                yield return null; // Attendre la fin du frame
            }

        }
    }

        IEnumerator SlideOnY()
        {

            // Initialisation des positions
            Vector2 startPosition = transform.position;
            Vector2 targetPosition = startPosition + new Vector2(0, slideDistanceUp);

            // Initialisation du temps écoulé
            float elapsedTime = 0;

            // Boucle pour interpoler la position
            while (elapsedTime < slideDurationUp)
            {
                // Interpolation
                float t = elapsedTime / slideDurationUp;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);

                elapsedTime += Time.deltaTime;
                yield return null; // Attendre la fin du frame
            }

            // S'assurer que la position finale est atteinte
            transform.position = targetPosition;
        }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isPaused = true;
        StartCoroutine(SlideOnY());

        if(collision.gameObject.layer==3)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isPaused = false;
        lifeSpanLeft = lifeSpanLeft - 1;
        if (lifeSpanLeft == 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BubblePop() 
    {
        bubbleAnimator.SetTrigger("Pop");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
