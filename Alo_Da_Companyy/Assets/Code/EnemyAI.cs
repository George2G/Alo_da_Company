using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed_for_Patrol;
    public bool MoveRight;
    public Transform player;
    private bool trigger;
    public float stopdDistance;
    public CircleCollider2D colliderr;
    private MeleEnemy attack;
    public Animator anim;
    

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    bool stopmoveing = false;


    private void Start()
    {
        attack = GetComponent<MeleEnemy>();
        anim = GetComponent<Animator>();
        
    }


    private void Update()
    {
        //how to stop cheking after the player is dead
        if (player != null && Vector2.Distance(transform.position, player.position) < colliderr.radius  )
        {
            if (trigger == true)
            {
            anim.SetBool("isChasing", true);
                
                if (Vector2.Distance(transform.position,player.position) > stopdDistance )
                {
                    anim.SetBool("isAttacking", false);

                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed_for_Patrol * Time.deltaTime);
                }
                else
                {
                    
                    anim.SetBool("isAttacking", true);
 
                    if (Time.time >= nextAttackTime)
                    {
                        stopmoveing = true;
                       
                      anim.SetTrigger("attack");
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
                    
                }
            }
            //in case of you hitting the enemy fron top and treigger disables it's self untill you re-enter the  trigger
            else
            {
                if (Vector2.Distance(transform.position, player.position) > stopdDistance)
                {            
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed_for_Patrol * Time.deltaTime);
                }

                else
                {
                    Debug.Log("y");
                }
            }

        }
        else 
        {
            anim.SetBool("isChasing", false);

            Debug.Log("_____L____ ");
            if (MoveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed_for_Patrol, 0, 0);
                transform.localScale = new Vector2(-9, 9);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed_for_Patrol, 0, 0);
                transform.localScale = new Vector2(9, 9);

            }
            
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
