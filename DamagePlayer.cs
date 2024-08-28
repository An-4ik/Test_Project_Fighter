using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Animator anim;
    public int damage;

    GameObject Ply;

    public bool player;
    public float rad;
    public Transform hook_r;
    public LayerMask Player_Layer;

    public AudioSource Auio_effect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Ply = GameObject.FindWithTag("Player");

        Auio_effect = GameObject.Find("push_foot_left").GetComponent<AudioSource>();
    }

    private void Update()
    {
        player = Physics.CheckSphere(hook_r.position, rad, Player_Layer);
    }

   

    public void hook_ataks()
    {

        

        if (player)
        {


            Ply.GetComponent<enemyTakeDmg>().Is_dmg_Up = true;
             Ply.GetComponent<enemyTakeDmg>().EnemyHealth();
            Auio_effect.Play();
            GameObject.Find("HP_bar").GetComponent<Health_Bar>().HP--;
            
        }
       
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hook_r.position, rad);
    }
}
