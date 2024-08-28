using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwn_enm : MonoBehaviour
{
    public GameObject Enm;
 
    private void Start()
    {
        
        StartCoroutine(spawn_enm());
    }

    private IEnumerator spawn_enm()
    {
        yield return new WaitForSeconds(15f);
        Instantiate(Enm, transform.position, Quaternion.identity);
        StartCoroutine(spawn_enm());
    }

}
