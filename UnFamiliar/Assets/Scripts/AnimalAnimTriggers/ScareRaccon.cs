using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareRaccon : MonoBehaviour
{
    public bool CanScare = false;
    public  Animator RaccoonAnimator;

    public AudioSource rummageAudioSource;
    //public AudioClip jumpIn;
    public AudioSource jumpInAudioSource;
    //public AudioClip raccoonClip;
    public AudioSource raccoonAudioSource;
    
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
            rummageAudioSource.enabled = false;
            jumpInAudioSource.Play();
            raccoonAudioSource.Play();
        }
    }
}
