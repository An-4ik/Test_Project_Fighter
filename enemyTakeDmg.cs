
using UnityEngine;


public class enemyTakeDmg : MonoBehaviour
{
    public Animator anim; //    �������� ������
    public bool Is_dmg_Up = false; //  ���� ������
    public bool Is_dmg_Down = false; // ���� �����
    public bool Is_Combo = false; // ���� �� �����

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


    //          <--------- ����������� ����� � �������� ---------->
     void Take_Damage()
    {
        if (Is_dmg_Up) // ���� ������
        {
            health--;
            anim.SetTrigger("Dmg_up");
            Is_dmg_Up = false;
            
        }

        if (Is_dmg_Down) // ���� �����
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




    // <------- ������� ������������ ����� -------->


   
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
