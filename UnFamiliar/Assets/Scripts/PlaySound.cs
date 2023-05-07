using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound: MonoBehaviour
{
    public AudioSource playSound;
    public AudioClip sound1;
    public AudioClip sound2;

     public void OnTriggerEnter(Collider other) 
     {
        if (other.gameObject.tag == "Ground")
        {
            playSound.Play();
            Debug.Log("Play");
        }
     }

    public void PlaySound1()
    {
        playSound.clip= sound1;
        playSound.Play();
    }

    public void PlaySound2()
    {
        playSound.clip = sound2;
        playSound.Play();
    }
}
