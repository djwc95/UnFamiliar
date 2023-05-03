using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxPlaying : MonoBehaviour
{
    public Animator foxAnimator;
    public PlayerMovement2 pm2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foxAnimator.SetTrigger("Play");
            StartCoroutine(LockPlayer());
        }
    }
    
    IEnumerator LockPlayer()
    {
        pm2.LockMovement();
        yield return new WaitForSeconds(12.25f);
        Destroy(this.gameObject);
        pm2.UnLockMovement();
    }
}
