using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FallingRocks : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement2 pm2;
    public CinemachineImpulseSource screenShake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Fall");
            pm2.LockMovement();
            StartCoroutine(ScreenShake());
        }
    }

    public IEnumerator ScreenShake()
    {
        yield return new WaitForSeconds(1.25f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.25f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.25f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.25f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.25f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.25f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.25f);
        screenShake.GenerateImpulse();
        pm2.UnLockMovement();
    }
}
