using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class udar_audio : MonoBehaviour
{
  public AudioSource udar_vozduh, udar_po_litsu_1, udar_po_litsu_2, udar_nogoy_1;

    private void Awake()
    {
        udar_vozduh = GetComponent<AudioSource>();
        udar_po_litsu_1 = GameObject.Find("Push_L").GetComponent<AudioSource>();
        udar_po_litsu_2 = GameObject.Find("Hook_R").GetComponent<AudioSource>();
        udar_nogoy_1 = GameObject.Find("push_foot_left").GetComponent<AudioSource>();
    }



    //   <---------- Воспроизведение звуковых эффектов удара ---------->
    public void Play_udar_vozduh()
    {
        udar_vozduh.pitch = Random.Range(0.5f, 1.2f);
        udar_vozduh.Play();
    }

    public void Play_udar_po_litsu_1()
    {
        udar_po_litsu_1.pitch = Random.Range(0.5f, 1.2f);
        udar_po_litsu_1.Play();
    }

    public void Play_udar_po_litsu_2()
    {
        udar_po_litsu_2.pitch = Random.Range(0.5f, 1.2f);
        udar_po_litsu_2.Play();
    }

    public void Play_udar_nogoy_1()
    {
        udar_nogoy_1.pitch = Random.Range(1.2f, 1.5f);
        udar_nogoy_1.Play();
    }

    
}
