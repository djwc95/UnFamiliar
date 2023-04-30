using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPushing : MonoBehaviour
{
   public AudioSource rockSound;

    void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player"){rockSound.Play();
    Debug.Log("Playing Sound");}
    
         

   }

   void OnTriggerExit(Collider other) {
    if (other.gameObject.tag == "Player"){rockSound.Stop();}
    
   }
}
