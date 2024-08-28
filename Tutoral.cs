using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutoral : MonoBehaviour
{
    public AudioSource audio;
    private bool already = false;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    private void FixedUpdate()
    {
        Play_Audio();
    }


    void Play_Audio()
    {

        if(GameObject.Find("HP_bar").GetComponent<Health_Bar>().HP == 9 && !already)
        {
            audio.Play();
            already = true;
        }
    }


   
}
