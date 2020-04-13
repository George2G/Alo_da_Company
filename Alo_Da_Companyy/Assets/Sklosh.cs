using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sklosh : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private Enemyy enmy;
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        currentHealth -= 20;

    }
}
