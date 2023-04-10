using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] float chase_Range;
    [SerializeField] float turn_speed;

    float distance_to = Mathf.Infinity;

    NavMeshAgent navmesh_agent;
    Enemy_health health_enemy;
    Transform target;

    bool isProvoked = false;
   


    void Start()
    {
        navmesh_agent = GetComponent<NavMeshAgent>();
        health_enemy = GetComponent<Enemy_health>();
        target = FindAnyObjectByType<Player_health>().transform;
    }

    
    void Update()
    {
        if (health_enemy.Is_Dead())
        {
            enabled = false; 
            navmesh_agent.enabled = false;
        }
        else
        {
            distance_to = Vector3.Distance(target.position, transform.position);

            if (isProvoked)
            {
                Engage_target();
            }
            else if (distance_to < chase_Range)
            {
                isProvoked = true;
            }
        }    
    }




    void Engage_target()
    {
        Face_toPlayer();
        if (distance_to >=navmesh_agent.stoppingDistance)
        {
            Chase_target();
        }

        if(distance_to <= navmesh_agent.stoppingDistance)
        {
            Attack_target();
        }
        
    }






    public void On_damageTaken()
    {
        isProvoked = true;
    }





    void Chase_target()
    {        
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navmesh_agent.SetDestination(target.position);
    }

    void Attack_target()
    {
        GetComponent<Animator>().SetBool("attack",true);
    }


    public void Face_toPlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look_Rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_Rotation, Time.deltaTime * turn_speed);
    }





    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, chase_Range);        
    }

}
