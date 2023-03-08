using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] Ammo_slot[] ammo_Slots;


    [System.Serializable]
    private class Ammo_slot
    {
        public Ammo_type ammo_Type;
        public int ammo_Amount;
    }




    public int current_Ammo(Ammo_type _ammo_Type)
    {
        return GetAmmoSlot(_ammo_Type).ammo_Amount;
    }

    public void decrease_Ammo(Ammo_type _ammo_Type)
    {
        GetAmmoSlot(_ammo_Type).ammo_Amount--;
    }

    public void increase_Ammo(Ammo_type _ammo_Type, int pick_ammo_amount)
    {
        GetAmmoSlot(_ammo_Type).ammo_Amount += pick_ammo_amount;
    }




    private Ammo_slot GetAmmoSlot(Ammo_type ammo_Type)
    {
        foreach(Ammo_slot slot in ammo_Slots)
        {
            if (slot.ammo_Type == ammo_Type)
            {
                return slot;
            }
            
        }
        return null;
    }

}
