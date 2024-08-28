
using UnityEngine;

public class Screen_toch : MonoBehaviour
{
    public Animator anim; // брать компонент аниматор из игрока

    
    public void push_leg()
    {
        anim.SetTrigger("Bk_push_left_A");
    }
    public void push_hend()
    {
        anim.SetTrigger("hp_straight_right_A");
    }
}
