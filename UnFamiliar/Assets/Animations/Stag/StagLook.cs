using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagLook: MonoBehaviour
{
    public Animator StagSitAnimator;
    private bool canTrigger = true;
    //public PlayerMovement2 pm2;
    //public MoveAtoB moveInReverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && canTrigger)
        {
            StagSitAnimator.SetTrigger("Look");
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() 
    {
        canTrigger = false;
        yield return new WaitForSeconds(4);
        canTrigger = true;
    }
}