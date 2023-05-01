using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressSwitch : MonoBehaviour
{
    public Animator switchPress;
    public AudioSource audioSource;
    public AudioClip stoneGrind;
    public AudioClip stoneGrindHi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchPress.SetTrigger("Depress");
            audioSource.clip = stoneGrind;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchPress.SetTrigger("Expand");
            audioSource.clip = stoneGrindHi;
            audioSource.Play();
        }
    }
}
