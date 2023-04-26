using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerryGo: MonoBehaviour
{
    public AudioSource playSound;

     void OnTriggerEnter(Collider other) {

        playSound.Play();
        
    }
}
