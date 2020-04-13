using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Pound : MonoBehaviour
{
    public int dmg;
    public int bounce;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Top")
        {

            collision.gameObject.transform.parent.gameObject.GetComponent<Enemyy>().TakeDamage(dmg);
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
    }
}
