using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float restore_angle;
    [SerializeField] float add_intens;

    private void OnTriggerEnter(Collider b)
    {
        if (b.gameObject.tag == "Player")
        {
            b.GetComponentInChildren<flashlight>().Restore_light_angle(restore_angle);
            b.GetComponentInChildren<flashlight>().Add_light_intens(add_intens);
            Destroy(gameObject);
        }
    }
}
