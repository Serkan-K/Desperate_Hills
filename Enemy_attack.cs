using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
    Player_health target;
    [SerializeField] float damage_enemy;

    
    void Start()
    {
        target = FindAnyObjectByType<Player_health>();

    }

   
    public void Enemy_attack_damage()
    {
        if (target == null) return;
        target.Take_damage(damage_enemy);
        target.GetComponent<Damage_UI>().Damage_screen();
        
    }
}
