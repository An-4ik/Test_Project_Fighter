
using UnityEngine;

public class Joystik_move : MonoBehaviour
{
    public float speed;

    public GameObject Player_pref;
    public GameObject Player_Parent;

    public Animator anim;
    private void Start()
    {
        //anim = Player_pref.GetComponent<Animator>();
    }

    private void Update()
    {
        Move_horizontal_Left();
        Move_horizontal_Right();

        move_up_dwn();
        move_end_up();
    }


    // <-------- движение влево -------->

    private bool On_down_l = false;

    public void Btn_down_l()
    {
        Player_Parent.GetComponent<Move>().use_joystic = true;
        anim.SetBool("Is_Move", true);
        On_down_l = true;
      
    }
    public void Btn_up_l()
    {
        Player_Parent.GetComponent<Move>().use_joystic = false;
        On_down_l = false;
        anim.SetBool("Is_Move", false);
    }


    public void Move_horizontal_Left()
    {
        if (On_down_l)
        {
            

            Player_Parent.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);

            Vector3 rotate = Player_pref.transform.eulerAngles;
            rotate.y = 180;
            Player_pref.transform.rotation = Quaternion.Euler(rotate);

          

        }
    }


    // <-------- движение вправо -------->

    private bool On_down_r = false;
    public void Btn_down_r()
    {
        Player_Parent.GetComponent<Move>().use_joystic = true;
        On_down_r = true;
        anim.SetBool("Is_Move", true);
    }
    public void Btn_up_r()
    {
        Player_Parent.GetComponent<Move>().use_joystic = false;
        On_down_r = false;
        anim.SetBool("Is_Move", false);
    }

    public void Move_horizontal_Right()
    {
        if (On_down_r)
        {
          

            Player_Parent.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);

            Vector3 rotate = Player_pref.transform.eulerAngles;
            rotate.y = 0;
            Player_pref.transform.rotation = Quaternion.Euler(rotate);
        }
    }




    // <-------- движение вверх -------->
    public bool moveUp = false;
  

        public void Move_upBut_down()
        {
          Player_Parent.GetComponent<Move>().use_joystic = true;
          moveUp = true;
          anim.SetBool("Is_Move", true);
 

        }
        public void Move_upBut_Up()
        {
        Player_Parent.GetComponent<Move>().use_joystic = false;
        moveUp = false;
            anim.SetBool("Is_Move", false);


        }

    private void move_up_dwn()
    {
        if (moveUp)
            Player_Parent.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
    }


    // <-------- движение вниз -------->

    public bool moveDown = false;

        public void Move_DownBut_Down()
        {

          Player_Parent.GetComponent<Move>().use_joystic = true;
          moveDown = true;
            anim.SetBool("Is_Move", true);

           

        }
        public void Move_DownBut_Up()
        {

            Player_Parent.GetComponent<Move>().use_joystic = false;
           moveDown = false;
            anim.SetBool("Is_Move", false);



        }
    private void move_end_up()
    {
        if(moveDown)
            Player_Parent.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
    }
}
