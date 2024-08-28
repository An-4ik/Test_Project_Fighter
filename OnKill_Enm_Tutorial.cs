
using UnityEngine;

public class OnKill_Enm : MonoBehaviour
{
    public GameObject Tutorial_obj;
    private AudioSource audio;

    private void Awake()
    {
        audio = Tutorial_obj.GetComponent<AudioSource>();
    }
    private void OnDestroy()
    {
        audio.Play();
    }
}
