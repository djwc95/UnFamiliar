using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareRaccon : MonoBehaviour
{
    public bool CanScare = false;
    public  Animator RaccoonAnimator;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player"){
            CanScare = true;
        }
    }
   private void OnTriggerExit(Collider other) 
   {
        if (other.gameObject.tag == "Player"){
            CanScare = false;
        }
   }
    private void Update()
    {
        if (CanScare && Input.GetKeyDown(KeyCode.E))
        {
            RaccoonAnimator.SetTrigger("Scare");
        }
    }
}
