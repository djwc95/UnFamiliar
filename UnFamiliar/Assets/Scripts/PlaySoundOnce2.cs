using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce2 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            source.clip = clip;
            source.Play();
        }
    }
}
