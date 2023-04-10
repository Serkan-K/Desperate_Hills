using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    Animator my_Anim;

    void Start()
    {
        my_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        Open_chest();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Open_chest();
        }
    }


    void OnTriggerExit(Collider ch)
    {
        if (ch.gameObject.tag == "Player")
        {
                bool isOpen = my_Anim.GetBool("is_Open");
                my_Anim.SetBool("is_Open", false);
        }
    }



    void Open_chest()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isOpen = my_Anim.GetBool("is_Open");
            my_Anim.SetBool("is_Open", !isOpen);
        }
    }




}
