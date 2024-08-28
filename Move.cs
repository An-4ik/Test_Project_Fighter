
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed; // �������� ������
    public Animator anim; // ����� ��������� �������� �� ������

    public GameObject Audio_Effects;

    public GameObject Player_pref;

    private void Start()
    {
        Time.timeScale = 1;
        Audio_Effects = GameObject.Find("Player_Move");
    }
    void Update()
    {
        PlMoveXY(); // ���-� �������� �� XY
        BK_push_hand(); // �������� ������
       
    }



    public bool use_joystic = false;

    public void PlMoveXY()
    {
           // <----- ������������ �� ����������� � �������� ----->
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * h);
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed * v);


        //     <--- �������� ������ ---->
        if (h != 0 ||  v != 0)
        {
            anim.SetBool("Is_Move", true);
        }
        else 
        {
            if (!use_joystic)
            anim.SetBool("Is_Move", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 rotate = Player_pref.transform.eulerAngles;
            rotate.y = 180;
            Player_pref.transform.rotation = Quaternion.Euler(rotate);
        } 
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 rotate = Player_pref.transform.eulerAngles;
            rotate.y = 0;
            Player_pref.transform.rotation = Quaternion.Euler(rotate);
        }
       
    }

    


    //      <------ �������� ������ ------->
    public void BK_push_hand()
    {
        if (Input.GetKeyDown(KeyCode.K)) // ���� �����
        {
            anim.SetTrigger("Bk_push_left_A");
        }

        if (Input.GetKeyDown(KeyCode.O)) // ���� �����
        {
            anim.SetTrigger("hp_straight_right_A");
        }
    }

    




    //           <-------- ���������� � ��������� ����� ������ --------->

    public Transform Chek_hook_R, Chek_hook_L, Ckek_push_L, Ckek_push_R; // ����� ����� ���������
    public LayerMask enemy; // ���� �� ������� �����
    public Vector3 kub_chek; // ����� ����
    Quaternion quaternion = Quaternion.identity;



    //     ------------ ������ ���� ---------
    public void hook_ataks()
    {
        
        Collider[] enemies = Physics.OverlapBox(Chek_hook_R.position, kub_chek, quaternion, enemy);   // �������� ��� ������� � �������� ������� OverlapBox
      
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyTakeDmg>().Is_dmg_Up = true;
            enemies[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_po_litsu_1();
            }

        }

        if (enemies.Length < 1) // ����������� *���� �� �������
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
       
    }
    //     ------------ ����� ���� ---------
    public void hook_ataks_L()
    {

        Collider[] enemies = Physics.OverlapBox(Chek_hook_L.position, kub_chek, quaternion, enemy);   // �������� ��� ������� � �������� ������� OverlapBox

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyTakeDmg>().Is_dmg_Up = true;
            enemies[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_po_litsu_1();
            }

        }

        if (enemies.Length < 1) // ����������� *���� �� �������
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }

    }



    //      ------------ ����� ���_���� *�����-----------
    public void hook_ataks_Combo()
    {

        Collider[] enemies = Physics.OverlapBox(Chek_hook_L.position, kub_chek, quaternion, enemy);   // �������� ��� ������� � �������� ������� OverlapBox

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyTakeDmg>().Is_Combo = true;
            enemies[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_po_litsu_2();
            }

        }

        if (enemies.Length < 1) // ����������� *���� �� �������
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
    }


    //      ---------- ���� ����� ����� -------------
    public void push_leg()
    {
        Collider[] enemies_2 = Physics.OverlapBox(Ckek_push_L.position, kub_chek, quaternion, enemy);
        for (int i = 0; i < enemies_2.Length; i++)
        {
            enemies_2[i].GetComponent<enemyTakeDmg>().Is_dmg_Down = true;
            enemies_2[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies_2[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_nogoy_1();
            }
        }

        if (enemies_2.Length < 1) // ����������� *���� �� �������
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
    }

    //      ---------- ���� ������ ����� *����� -------------
    public void push_leg_R_Combo()
    {
        Collider[] enemies_2 = Physics.OverlapBox(Ckek_push_R.position, kub_chek, quaternion, enemy);
        for (int i = 0; i < enemies_2.Length; i++)
        {
            enemies_2[i].GetComponent<enemyTakeDmg>().Is_Combo = true;
            enemies_2[i].GetComponent<enemyTakeDmg>().EnemyHealth();
            if (enemies_2[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_nogoy_1();
            }
        }


        if (enemies_2.Length < 1) // ����������� *���� �� �������
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Chek_hook_R.position, kub_chek); // ������ ����

        Gizmos.DrawWireCube(Chek_hook_L.position, kub_chek); // ����� ����

        Gizmos.DrawWireCube(Ckek_push_L.position, kub_chek); // ���� �����

        Gizmos.DrawWireCube(Ckek_push_R.position, kub_chek); // ������ ����
    }
}
