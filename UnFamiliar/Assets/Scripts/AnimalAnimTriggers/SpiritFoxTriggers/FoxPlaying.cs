using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxPlaying : MonoBehaviour
{
    public Animator foxAnimator;
    public PlayerMovement2 pm2;
    public MoveAtoB moveAtoB;
    public MoveAtoB moveInReverse;

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
        moveAtoB.Move();
        yield return new WaitForSeconds(3.25f);
        moveAtoB.StopMoving();
        yield return new WaitForSeconds(5.7f);
        moveInReverse.Move();
        yield return new WaitForSeconds(2.25f);
        Destroy(this.gameObject);
        pm2.UnLockMovement();
    }
}
