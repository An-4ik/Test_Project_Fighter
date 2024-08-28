
using UnityEngine;
using UnityEngine.AI;

public class EnemyPos : MonoBehaviour
{

    public Transform Chek_; // проверка области атаки
    public LayerMask Player_Layer; // слой на котором игрок
    public float Radius; // радиес чека атаки
   


    public bool Player = false;
    public Animator anim;

    public bool can_wallk;

    public Transform target;
    NavMeshAgent agent;

    public float TimeBtwAtak = 2f;
    public float Res_TimeBtwAtak = 2;
    public void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Is_Move", false);
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;
        GameObject Ply = GameObject.FindWithTag("Player");

    }

    public void Update()
    {
        Player = Physics.CheckSphere(Chek_.position, Radius, Player_Layer);

        if (Player)
        {
            transform.LookAt(target);
            if (target != null)
            Is_Player();
        }
        else
        {
            Is_NOT_Player();

        }

    }

    public void Is_Player()
    {
        if (TimeBtwAtak <= 0)
        {

            agent.SetDestination(transform.position);
            anim.SetBool("Is_Move", false);
            anim.SetTrigger("hp_straight_right_A");
            TimeBtwAtak = Res_TimeBtwAtak;
        }
        else
        {
            TimeBtwAtak -= Time.deltaTime;
        }



    }
    public void Is_NOT_Player()
    {

        agent.SetDestination(target.position);

        if(can_wallk)
        anim.SetBool("Is_Move", true);
    }


 




    private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Chek_.position, Radius); 
        }
 }
