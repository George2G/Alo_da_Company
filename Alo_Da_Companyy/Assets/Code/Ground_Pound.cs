using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Pound : MonoBehaviour
{
    public int dmg;
    public int bounce;
    private Rigidbody2D rb;

    public Animator ainm;

    private bool isGoundedd;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatISGround;
    public BoxCollider2D boxCL1;

    public float smash;

    private void Start()
    {
        boxCL1.enabled = false;
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGoundedd == false)
        {
            ainm.SetTrigger("smash");
            boxCL1.enabled = true;
            rb.velocity = Vector2.down * smash;
            
 
        }
        
    }
    private void FixedUpdate()
    {
        
        isGoundedd = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatISGround);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Top")
        {
            rb.velocity = new Vector2(rb.velocity.x, bounce);
            collision.gameObject.transform.parent.gameObject.GetComponent<Enemyy>().TakeDamage(dmg);
            boxCL1.enabled = false;
        }
    }
}
