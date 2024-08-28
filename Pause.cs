
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
   

    public void Pause_panel()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Rusem_game()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
