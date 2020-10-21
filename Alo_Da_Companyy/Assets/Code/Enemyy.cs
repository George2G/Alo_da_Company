using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    public Animator anim;

    
    public int maxHealth = 100;
    int currentHealth;
    private float deadTimer = 2;
    public float speed;

    public BoxCollider2D boxCl;
    public Rigidbody2D rb;


    private scene_transition sceneTransitions;
   

    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        sceneTransitions = FindObjectOfType<scene_transition>();
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;

        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
            
            sceneTransitions.LoadScene("win"); 
           
        }
    }

    public void Die()
    {
        
        Debug.Log("Dead");

        anim.SetBool("isDead", true);
        boxCl.enabled = false;
        Destroy(rb);
        


        Destroy(gameObject, deadTimer);
        //desable the box collider
        GetComponent<Collider2D>().enabled = false;
        //disable enemy/ script
        this.enabled = false;

    }
}
