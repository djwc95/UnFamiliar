using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRun : MonoBehaviour
{
    public Animator DeerAnimator;
    //public PlayerMovement2 pm2;
    public MoveAtoB moveAtoB;
    //public MoveAtoB moveInReverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DeerAnimator.SetTrigger("DeerScare");
            moveAtoB.Move();
            StartCoroutine(DestroyOverTime());
        }
    }
    IEnumerator DestroyOverTime()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
    
    
}