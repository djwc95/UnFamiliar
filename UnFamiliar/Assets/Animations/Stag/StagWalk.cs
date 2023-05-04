using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagWalk : MonoBehaviour
{
    public Animator StagAnimator;
    //public PlayerMovement2 pm2;
    public MoveAtoB moveAtoB;
    public float waitTime = 1.25f;
    //public MoveAtoB moveInReverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SpookDeer());
            StagAnimator.SetTrigger("Look");
        }
    }
    IEnumerator DestroyOverTime()
    {
        yield return new WaitForSeconds(30);
        Destroy(this.gameObject);
    }

    IEnumerator SpookDeer()
    {
        yield return new WaitForSeconds(waitTime);
        moveAtoB.Move();
        StartCoroutine(DestroyOverTime());
    }
}