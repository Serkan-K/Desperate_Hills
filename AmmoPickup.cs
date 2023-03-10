using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] int pickup_ammo_Amount;
    [SerializeField] Ammo_type pickup_ammo_type;


    private void Update()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion look_Rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_Rotation, 1f);
    }

    private void OnTriggerEnter(Collider ammo_oo)
    {
        if (ammo_oo.gameObject.tag.Equals("Player"))
        {
            FindAnyObjectByType<Ammo>().increase_Ammo(pickup_ammo_type, pickup_ammo_Amount);
            Destroy(gameObject);
        }
    }
}
