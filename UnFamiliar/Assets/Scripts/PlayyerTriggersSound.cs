using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayyerTriggersSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public Collider objectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.clip = clip;
            audioSource.Play();
            StartCoroutine(WaitThenDestroy());
        }
    }
     IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(.5f);
        objectToDisable.enabled= false;
    }
}
