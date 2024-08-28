using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataks : MonoBehaviour
{
    public GameObject plyerSript;

    
    public void Atak_leg()
    {
        plyerSript.GetComponent<Move>().push_leg();
    }

    public void Atak_hook()
    {
        plyerSript.GetComponent<Move>().hook_ataks();
    }
    public void Atak_hook_L()
    {
        plyerSript.GetComponent<Move>().hook_ataks_L();
    }


    public void Combo_Ataks()
    {
        plyerSript.GetComponent<Move>().hook_ataks_Combo();
    }

    public void Combo_Ataks_leg()
    {
        plyerSript.GetComponent<Move>().push_leg_R_Combo();
    }





   // public GameObject Enemy_Sript;



}

