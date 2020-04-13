using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : Enemyy
{
    public float stopdDistance;

    private float attackTime;

    private void Update()
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
}
