using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRun : MonoBehaviour
{
    public bool CanScare = false;
    public  Animator DobermanAnimator;
    
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
            DobermanAnimator.SetTrigger("Run");
        }
    }
}