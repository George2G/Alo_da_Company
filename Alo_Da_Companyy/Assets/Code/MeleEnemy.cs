using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : Enemyy
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayer;

    public int attackDmg;
    public Player_Movement player;


    public void AttackMotion()
    {
        if (player != null)
        {

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

}
   

