using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound: MonoBehaviour
{
    public AudioSource playSound;

     public void OnTriggerEnter(Collider other) 
     {
        if (other.gameObject.tag == "Ground")
        {
            playSound.Play();
            Debug.Log("Play");
        }
     }
}
