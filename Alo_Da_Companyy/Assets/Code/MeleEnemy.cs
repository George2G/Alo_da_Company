using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : Enemyy
{
  //  public float stopdDistance;

    

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayer;

    public int attackDmg = 10;
    private Player_Movement player;

    private void Start()
    {
        player = GetComponent<Player_Movement>();
    }


    public void AttackMotion()
     {
        if (player == null)
        {
            anim.SetTrigger("attack");

            Debug.Log("yap");

            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayer);


            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<Player_Movement>().TakeDamage(attackDmg);
            }

        }
       
    }

    public void OnDrawGizmosSelected()//draw stuff in the editor that are usually unseeable
     {
         if (attackPoint == null)
         {
             return;
         }
         Gizmos.DrawSphere(attackPoint.position, attackRange);
     }
     
    /*private void Update()
     {
         if (player != null)
         {
             if (Vector2.Distance(transform.position, player.position) > stopdDistance)
             {
                 transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
             }
             else
             {
                 if (Time.time >= attackTime)
                 {
                     StartCoroutine(Attack());
                     attackTime = Time.time + timeBtwAttacks;
                 }
             }
         }
     }

     IEnumerator Attack()
     {
         player.GetComponent<Player_Movement>().TakeDamage(dmg);

         yield return null;
     }
    */
}
