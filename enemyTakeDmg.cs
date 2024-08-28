
using UnityEngine;


public class enemyTakeDmg : MonoBehaviour
{
    public Animator anim; //    анимации врагов
    public bool Is_dmg_Up = false; //  урон сверху
    public bool Is_dmg_Down = false; // урон снизу
    public bool Is_Combo = false; // урон от комбо

    public int health = 10; 

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

     void Update()
    {
        Take_Damage();
       // EnemyHealth();
      
    }


    //          <--------- Направление удара и анамации ---------->
     void Take_Damage()
    {
        if (Is_dmg_Up) // урон сверху
        {
            health--;
            anim.SetTrigger("Dmg_up");
            Is_dmg_Up = false;
            
        }

        if (Is_dmg_Down) // урон снизу
        {
            health--;
            anim.SetTrigger("Dmg_down");
            Is_dmg_Down = false;
        }

        if (Is_Combo)
        {
            health--;
            anim.SetTrigger("Combo");
            
            Is_Combo = false;
        }
        
    }




    // <------- удалить побежденного врага -------->


   
    public void EnemyHealth()
    {
        if (health <= 0)
        {
          
            anim.SetBool("death", true);
            Invoke("destroy_enemy", 1.5f);
          
        }
       
    }
  




    void destroy_enemy()
    {
        Destroy(gameObject);
    }
}
