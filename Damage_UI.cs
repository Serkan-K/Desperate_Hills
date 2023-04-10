using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_UI : MonoBehaviour
{

    [SerializeField] Canvas damage_canvas;
    [SerializeField] float damage_time;


    void Start()
    {
        damage_canvas.enabled = false;
    }


    public void Damage_screen()
    {
        StartCoroutine(Show_blood());
    }
   
    IEnumerator Show_blood()
    {
        damage_canvas.enabled = true;
        //damage_canvas.GetComponentInChildren<Image>.().CrossFadeAlpha(0f, damage_time, false);

        yield return new WaitForSeconds(damage_time);

        damage_canvas.enabled = false;
        //damage_canvas.GetComponentInChildren<Image>.().CrossFadeAlpha(1f, 0, true);
    }
}
