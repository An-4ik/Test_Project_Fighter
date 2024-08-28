using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour

{

     Image Helath_BAR;
    public float max_Health = 10;
    public float HP;

    void Start()
    {
        Helath_BAR = GetComponent<Image>();
        HP = max_Health;
    }

   
    void Update()
    {
        Helath_BAR.fillAmount = HP / max_Health;

        pleyer_Death();
    }

    public void pleyer_Death()
    {
        if(HP <= 0)
        {
            GameObject.Find("Directional_Light").GetComponent<GameOver>().Game_over();
        }
    }
}
