using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FallingRocks : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement2 pm2;
    public CinemachineImpulseSource screenShake;
    private bool canActivate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canActivate= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate)
        {
            animator.SetTrigger("Fall");
            pm2.LockMovement();
            StartCoroutine(ScreenShake());
            canActivate= false;
        }
    }
}
