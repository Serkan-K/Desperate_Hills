using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour
{
    [SerializeField] float health;

    bool isDead = false;



    public bool Is_Dead()
    {
        return isDead;
    }



    public void Take_damage(float damage)
    {
        BroadcastMessage("On_damageTaken");

        health -= damage;


        if (health <= 0)
        {
            Die();
        }
    }



    void Die()
    {
        if (isDead) return;
        isDead = true;

        GetComponent<Animator>().SetTrigger("death");
        Destroy(gameObject, 10f);
    }
}
