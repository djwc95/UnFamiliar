using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakenElder : MonoBehaviour
{
    public bool canAwaken = false;
    public GameObject cameraToDisable;
    public CinemachineVirtualCamera newCamera;
    public PlayerMovement2 pm2;
    public Animator elderAnimator;
    public Animator lightAnimator;

    public GameObject portal;
    public RespawnScript respawnScript;

    public RascalAnimations rascalAnimations;

    public GameObject rascal;
    public GameObject spiritRascal;
    public Animator particlesExchange;
    public GameObject particlesToActivate;
    private Vector3 rascalPosition;

    public CinemachineImpulseSource screenShake;

    public MoveAtoB moveAtoB;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAwaken = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAwaken = false;
        }
    }
    private void Update()
    {
        if (canAwaken && Input.GetKeyDown(KeyCode.E))
        {
            if(pm2.move.x == 0)
            {
                rascalAnimations.SetIdle();
                rascalPosition = rascal.transform.position;
                cameraToDisable.SetActive(false);
                pm2.LockMovement();
                canAwaken= false;
                StartCoroutine(StartMoving());
            }
        }
    }

    IEnumerator StartMoving() 
    {
        yield return new WaitForSeconds(1.5f);
        elderAnimator.SetTrigger("StartElder");
        yield return new WaitForSeconds(17.5f);
        moveAtoB.moveToB= true;
        moveAtoB.stayStill = false;
        yield return new WaitForSeconds(5f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(1.1f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(2.35f);
        screenShake.GenerateImpulse();
        yield return new WaitForSeconds(.35f);
        screenShake.GenerateImpulse();
        StartCoroutine(SoulExchange());
    }
    IEnumerator SoulExchange()
    {
        yield return new WaitForSeconds(4f);
        particlesToActivate.SetActive(true);
        particlesExchange.SetTrigger("Exchange");
        yield return new WaitForSeconds(6.3f);
        lightAnimator.SetTrigger("Play");
        yield return new WaitForSeconds(1.75f);
        Destroy(rascal);
        portal.SetActive(true);
        particlesToActivate.SetActive(false);
        Instantiate(spiritRascal, rascalPosition, Quaternion.identity);
        yield return new WaitForSeconds(1);
        newCamera.Priority = 100;
        newCamera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
        newCamera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        respawnScript.AssignPlayer();
        

    }
}
