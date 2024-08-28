
using UnityEngine;

public class Restrictions_Pos : MonoBehaviour
{
    public Transform Player;

    public void Start()
    {
        Player = GetComponent<Transform>();    
    }

    private void Update()
    {
        Restrictions();
    }
     void Restrictions()
    {
        if(Player.transform.position.x <= -2.9f)
        {
            Player.transform.position = new Vector3 (-2.89f, Player.transform.position.y, Player.transform.position.z);
        }

        if (Player.transform.position.x >= 0.7f)
        {
            Player.transform.position = new Vector3(0.69f, Player.transform.position.y, Player.transform.position.z);
        }

        if (Player.transform.position.z <= -18f)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -17.99f);
        }

        if (Player.transform.position.z >= 19f)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 18.99f);
        }
    }
}
