using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    [SerializeField] float health_player;


    public void Take_damage(float damage)
    {
        health_player -= damage;


        if (health_player <= 0)
        {
            GetComponent<Dead_handler>().Game_Over_screen();
        }
    }
}
