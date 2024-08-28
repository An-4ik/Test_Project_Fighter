
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed; // скорость игрока
    public Animator anim; // брать компонент аниматор из игрока

    public GameObject Audio_Effects;

    public GameObject Player_pref;

    private void Start()
    {
        Time.timeScale = 1;
        Audio_Effects = GameObject.Find("Player_Move");
    }
    void Update()
    {
        PlMoveXY(); // Фун-я движение по XY
        BK_push_hand(); // Анимации ударов
       
    }



    public bool use_joystic = false;

    public void PlMoveXY()
    {
           // <----- Передвижение по Горизонтали и Верикали ----->
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * h);
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed * v);


        //     <--- Анимация ходьбы ---->
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

    


    //      <------ Анимации ударов ------->
    public void BK_push_hand()
    {
        if (Input.GetKeyDown(KeyCode.K)) // удар ногой
        {
            anim.SetTrigger("Bk_push_left_A");
        }

        if (Input.GetKeyDown(KeyCode.O)) // удар рукой
        {
            anim.SetTrigger("hp_straight_right_A");
        }
    }

    




    //           <-------- Нахождение и нанесение урона врагам --------->

    public Transform Chek_hook_R, Chek_hook_L, Ckek_push_L, Ckek_push_R; // точки удара персонажа
    public LayerMask enemy; // слой на котором враги
    public Vector3 kub_chek; // объем куба
    Quaternion quaternion = Quaternion.identity;



    //     ------------ Правый Удар ---------
    public void hook_ataks()
    {
        
        Collider[] enemies = Physics.OverlapBox(Chek_hook_R.position, kub_chek, quaternion, enemy);   // Получаем все объекты в пределах области OverlapBox
      
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyTakeDmg>().Is_dmg_Up = true;
            enemies[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_po_litsu_1();
            }

        }

        if (enemies.Length < 1) // аудиоэффект *удар по воздуху
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
       
    }
    //     ------------ Левый Удар ---------
    public void hook_ataks_L()
    {

        Collider[] enemies = Physics.OverlapBox(Chek_hook_L.position, kub_chek, quaternion, enemy);   // Получаем все объекты в пределах области OverlapBox

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyTakeDmg>().Is_dmg_Up = true;
            enemies[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_po_litsu_1();
            }

        }

        if (enemies.Length < 1) // аудиоэффект *удар по воздуху
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }

    }



    //      ------------ Левый хук_Удар *комбо-----------
    public void hook_ataks_Combo()
    {

        Collider[] enemies = Physics.OverlapBox(Chek_hook_L.position, kub_chek, quaternion, enemy);   // Получаем все объекты в пределах области OverlapBox

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<enemyTakeDmg>().Is_Combo = true;
            enemies[i].GetComponent<enemyTakeDmg>().EnemyHealth();

            if (enemies[i] != null)
            {
                Audio_Effects.GetComponent<udar_audio>().Play_udar_po_litsu_2();
            }

        }

        if (enemies.Length < 1) // аудиоэффект *удар по воздуху
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
    }


    //      ---------- Удар левой ногой -------------
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

        if (enemies_2.Length < 1) // аудиоэффект *удар по воздуху
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
    }

    //      ---------- Удар правой ногой *комбо -------------
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


        if (enemies_2.Length < 1) // аудиоэффект *удар по воздуху
        {
            Audio_Effects.GetComponent<udar_audio>().Play_udar_vozduh();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Chek_hook_R.position, kub_chek); // правый удар

        Gizmos.DrawWireCube(Chek_hook_L.position, kub_chek); // левый удар

        Gizmos.DrawWireCube(Ckek_push_L.position, kub_chek); // удар ногой

        Gizmos.DrawWireCube(Ckek_push_R.position, kub_chek); // правая нога
    }
}
