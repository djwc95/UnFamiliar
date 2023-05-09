using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDog : MonoBehaviour
{
    public Animator animator;
    private bool canTrigger = true;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //animator= GetComponent<Animator>(); 
        audioSource= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && canTrigger)
        {
            animator.SetTrigger("alerted");
            canTrigger = false;
            audioSource.Play();
        }
    }

    public void Bark()
    {
        audioSource.Play();
    }
}
