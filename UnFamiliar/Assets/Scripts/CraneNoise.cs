using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneNoise : MonoBehaviour
{
    public AudioSource playSound;
private bool Canplay = false;

     void OnTriggerEnter(Collider other) {
        Canplay = true;
        

      
       
        
    }
    private void OnTriggerExit(Collider other) {
        Canplay = false;

        
    }
    private void Update() {
        if((Canplay)){
             if(Input.GetKeyDown(KeyCode.E)){

        playSound.Play();
        }
    }
}
}