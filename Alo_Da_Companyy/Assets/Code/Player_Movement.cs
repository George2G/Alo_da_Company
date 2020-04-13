using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    private float Movement;


    private Rigidbody2D rb;

    private bool Faceing = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatISGround;

    private int JUMPS;
    public int extraJUPS;

     private float moveX;
     private float moveY;
     private Vector3 moveDir;
     private bool IsDashButtonDown;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;
    public GameObject echo2;
    private Player_Movement player;


    private Animator anim;

    private void Start()
    {
        JUMPS = extraJUPS;
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        player = GetComponent<Player_Movement>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatISGround);


        Movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Movement * speed, rb.velocity.y);
        
        if (Faceing == false && Movement > 0)
        {
            Flip();
        }
        else if (Faceing == true && Movement < 0)
        {
            Flip();
        }

      
        if (IsDashButtonDown)
        {
            anim.SetTrigger("dash");

            float dashAmount = 1.5f;
            rb.MovePosition(transform.position + moveDir * dashAmount);
            
            IsDashButtonDown = false;
        }
        
       
    }

    private void Update()
    {

        if (Movement != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (isGrounded == true)
        {
            JUMPS = extraJUPS;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && JUMPS > 0)
        {
            anim.SetTrigger("jump");
            rb.velocity = Vector2.up * jump;
            JUMPS--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && JUMPS == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jump;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IsDashButtonDown = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;

        
        if (timeBtwSpawns <= 0 )
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameObject instace1 = (GameObject)Instantiate(echo2, transform.position, Quaternion.identity);
                Debug.Log("ya");
                Destroy(instace1, 1f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {

                GameObject instace2 = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Debug.Log("yappp11");
                Destroy(instace2, 1f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
    

                
        }
        else
        {
                timeBtwSpawns -= Time.deltaTime;
        }
        
    }

    public void Flip()
    {
        Faceing = !Faceing;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
