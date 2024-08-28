
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneManagering : MonoBehaviour
{
   

    public void Open_Menue()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Open_Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Start_Game()
    {
        SceneManager.LoadScene("11");
    }

   

    public void Quit_Game()
    {
        Application.Quit();
        Debug.Log("Game Quit");
        
    }

    
}
