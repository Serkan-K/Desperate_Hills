using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera zoom_camera;
    [SerializeField] GameObject _weapon_;
    [SerializeField] float zoom_normal;
    [SerializeField] float zoom_in;
    [SerializeField] Canvas crosshair;
    // [SerializeField] float zoom_Sens;
    //[SerializeField] float zoom_speed;


    bool zoom_Toggle = false;

    //FirstPersonController fps_control;
    

    private void OnDisable()
    {
        zoom_Out();
    }



    private void Start()
    {
        //fps_control = GetComponent<FirstPersonController>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoom_Toggle == false)
            {
                zoom_In();
            }
            else
            {
                zoom_Out();
            }
        }
        
    }





    private void zoom_In()
    {
        zoom_Toggle = true;
        zoom_camera.fieldOfView = zoom_in;
        

        //fps_control.RotationSpeed = zoom_Sens;

        crosshair.enabled = false;
        _weapon_.transform.localPosition = new Vector3(-0.078f, 0.03f, 0.316f);
    }



    private void zoom_Out()
    {
        zoom_Toggle = false;
        zoom_camera.fieldOfView = zoom_normal;

        if (crosshair.enabled != true) { return; }
        else
        {
            crosshair.enabled = true; 
        }
        
        _weapon_.transform.localPosition = new Vector3(0.1020012f, 0, 0.3279991f);
    }

    
}
