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

    private Animator anim;

    private void Start()
    {
        JUMPS = extraJUPS;
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
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

    }

    public void Flip()
    {
        Faceing = !Faceing;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
