using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibbitRoll : MonoBehaviour
{   
    
    private AudioSource audioSource;
    private float randNum;
    public AudioClip clip1;
    public AudioClip clip2;
    // Start is called before the first frame update
    void Start()
    {
           audioSource= GetComponent<AudioSource>();
    }

    public void Roll()
    {
        randNum= Random.Range(0f, 1f);
        if (randNum < 0.25f)
        {
            audioSource.clip = clip1;
            audioSource.Play();
        }
        else if (randNum > 0.75f)
        {
            audioSource.clip = clip2;
            audioSource.Play();
        }
    }
}
