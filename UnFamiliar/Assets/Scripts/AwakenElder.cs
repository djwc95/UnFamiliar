using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakenElder : MonoBehaviour
{
    public bool canAwaken = false;
    public GameObject cameraToDisable;
    public PlayerMovement2 pm2;
    public Animator elderAnimator;


    public GameObject rascal;
    public GameObject spiritRascal;
    public Animator particlesExchange;
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
            rascalPosition = rascal.transform.position;
            cameraToDisable.SetActive(false);
            pm2.LockMovement();
            StartCoroutine(StartMoving());
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
        particlesExchange.SetTrigger("Exchange");
        yield return new WaitForSeconds(6.3f);
        Destroy(rascal);
        Instantiate(spiritRascal, rascalPosition, Quaternion.identity);
    }
}
