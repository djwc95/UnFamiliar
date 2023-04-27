using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFalling : MonoBehaviour
{
    public AudioSource playSound;

     void OnTriggerEnter(Collider other) {


        if(Input.GetKeyDown(KeyCode.E)){
        playSound.Play();
        
    }
}
}
