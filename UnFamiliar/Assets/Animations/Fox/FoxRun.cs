using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxRun : MonoBehaviour
{
    public bool CanScare = false;
    public  Animator FoxAnimator;
    
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
            FoxAnimator.SetTrigger("FoxRun");
        }
    }
}