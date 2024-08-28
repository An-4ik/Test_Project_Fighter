
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public GameObject Loos_panel;
    public Animator anim;
    private AudioSource dead;

    private void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        dead = GetComponent<AudioSource>();
    }
    public void Game_over()
    {
        anim.SetBool("dath", true);
        dead.Play();
        Loos_panel.SetActive(true);
        Invoke("Stop_game", 2f);
    }

    private void Stop_game()
    {
        Time.timeScale = 0;
    }
}
