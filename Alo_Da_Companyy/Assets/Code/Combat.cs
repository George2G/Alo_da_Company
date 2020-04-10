using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 20;

    public float attackRate = 2f;
    private  float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemyy>().TakeDamage(attackDamage);
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
