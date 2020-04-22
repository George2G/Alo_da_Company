using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    public Transform player;
    private bool trigger;
    public float stopdDistance;
    public CircleCollider2D colliderr;
    

    

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < colliderr.radius)
        {
            Debug.Log("fk");
            if (trigger == true)
            {
                if (Vector2.Distance(transform.position,player.position) > stopdDistance )
                {
                     Debug.Log("hehee i hit you ");
                     transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
               
                else
                {
                    //attack
                    Debug.Log("gay");
                }
            }
            //in case of you hitting the enemy fron top and treigger disables it's self untill you re-enter the  trigger
            else
            {
                if (Vector2.Distance(transform.position, player.position) > stopdDistance)
                {
                    Debug.Log("hehee i hit you ");
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }

                else
                {
                    //attack
                    Debug.Log("gay");
                }
            }

        }
        else
        {
                Debug.Log("_____L____ ");

            /*if (MoveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-9, 9);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(9, 9);

            }
            */
        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
        
        if (collision.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
    }

}
