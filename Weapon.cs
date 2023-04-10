using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPS_camera;
    [SerializeField] float range;
    [SerializeField] float damage;
    [SerializeField] ParticleSystem muzzle_flash;
    [SerializeField] GameObject hit_Effect;
    [SerializeField] Ammo ammo_Slot;
    [SerializeField] Ammo_type ammo_Types;
    [SerializeField] float shoot_delay;
    [SerializeField] TextMeshProUGUI ammo_text;


    bool canShoot = true;


    private void OnEnable()
    {
        canShoot = true;
    }

   


    void Update()
    {
        Display_ammo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }



    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo_Slot.current_Ammo(ammo_Types)>0)
        {
            Muzzle_FX();
            Raycast();
            ammo_Slot.decrease_Ammo(ammo_Types);
        }

        yield return new WaitForSeconds(shoot_delay);
        canShoot = true;
    }





    void Display_ammo()
    {
        int current_ammo = ammo_Slot.current_Ammo(ammo_Types);
        ammo_text.text = current_ammo.ToString();
    }






    void Muzzle_FX()
    {
        muzzle_flash.Play();
    }




    void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPS_camera.transform.position, FPS_camera.transform.forward, out hit, range))
        {

            Create_hitFX(hit);

            Enemy_health target = hit.transform.GetComponent<Enemy_health>();
            if (target == null) return;
            target.Take_damage(damage);

        }
        else { return; }
    }

    void Create_hitFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(hit_Effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
        
    }
}
