using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon=0;

    void Start()
    {
        SetWeapon_Active();
    }


    void Update()
    {
        int previous_Weapon = currentWeapon;

        Switch_weapon_key();
        Switch_weapon_scroll();

        if (previous_Weapon != currentWeapon)
        {
            SetWeapon_Active();
        }

    }

  



    private void Switch_weapon_key()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }




    private void Switch_weapon_scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0 )
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }






    private void SetWeapon_Active()
    {
        int weaponIndex = 0;

        foreach(Transform weapon_ in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon_.gameObject.SetActive(true);
            }
            else
            {
                weapon_.gameObject.SetActive(false);
            }
            weaponIndex++;
        }

    }

}
