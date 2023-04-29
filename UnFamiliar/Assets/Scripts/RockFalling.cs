using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFalling : MonoBehaviour
{
    public AudioSource playSound;
    private bool Canplay = false;

     void OnTriggerEnter(Collider other) 
     {
        Canplay = true;
     }
    private void OnTriggerExit(Collider other) 
    {
        Canplay = false;
    }
    private void Update() 
    {
        if((Canplay))
        {
             if(Input.GetKeyDown(KeyCode.E))
             {
                StartCoroutine(StartSounds());
             }
        }
    }

    IEnumerator StartSounds()
    {
        yield return new WaitForSeconds(1.5f);
        playSound.Play();
    }
}
