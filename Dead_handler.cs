using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_handler : MonoBehaviour
{
    [SerializeField] Canvas game_Over_canvas;

    private void Start()
    {
        game_Over_canvas.enabled = false;
    }


    public void Game_Over_screen()
    {
        game_Over_canvas.enabled = true;
        Time.timeScale = 0;
        FindAnyObjectByType<WeaponSwitcher>().enabled = false;


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
