using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    private float deadTimer = 2;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Dead");

        anim.SetBool("isDead", true);
        

        Destroy(gameObject, deadTimer);
        //desable the box collider
        GetComponent<Collider2D>().enabled = false;
        //disable enemy/ script
        this.enabled = false;

    }
}
