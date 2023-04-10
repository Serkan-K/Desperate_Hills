using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    [SerializeField] float decrease_light_intens;
    [SerializeField] float decrease_light_angle;
    [SerializeField] float min_angle;


    Light flash;

    void Start()
    {
        flash = GetComponent<Light>();
    }

    void Update()
    {
        Decrease_intensity();
        Decrease_angle();
    }




    public void Restore_light_angle(float restore_angle)
    {
        flash.spotAngle = restore_angle;
    }

    public void Add_light_intens(float add_intens)
    {
        flash.intensity += add_intens;
    }




    private void Decrease_angle()
    {
        if (flash.spotAngle <= min_angle)
        {
            return;
        }
        else
        {
            flash.spotAngle -= decrease_light_angle * Time.deltaTime;
        }
        
    }

    private void Decrease_intensity()
    {
        flash.intensity -= decrease_light_intens * Time.deltaTime;
    }
}
