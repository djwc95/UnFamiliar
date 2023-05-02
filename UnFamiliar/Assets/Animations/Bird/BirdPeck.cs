using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPeck : MonoBehaviour
{
    public Animator BirdPecking;
    //public PlayerMovement2 pm2;
    public MoveAtoB walkMove;
    public MoveAtoB flyMove;
    public float waitTime = 1.25f;
    public float waitTimeHop = 1.25f;
    public bool canRotate = true;
    public float peckTime = 0.5f;
    public bool canMove = true;
    //public MoveAtoB moveInReverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SpookBird());
            BirdPecking.SetTrigger("Spook");
        }
    }
    IEnumerator DestroyOverTime()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }

    IEnumerator SpookBird()
    {
        yield return new WaitForSeconds(waitTime);
        flyMove.Move();
        StartCoroutine(DestroyOverTime());
    }

    IEnumerator WalkBird()
    {
        if (canMove)
        {
            walkMove.Move();
            Debug.Log("We are Walking");
            yield return new WaitForSeconds(waitTimeHop);
            canMove = false;

        }
        else if (!canMove) 
        {
            walkMove.StopMoving();
            Debug.Log("We have Stopped");
            yield return new WaitForSeconds(peckTime);
            canMove = true;
        }

    }

    IEnumerator RotateBird()
    {   
        if (canRotate) 
        {
            canRotate = false;
            transform.Rotate(0, 45, 0);
            yield return new WaitForSeconds(Random.Range(0.7f,2.5f));
            canRotate = true;

        }

    }
    private void Update()
    {
        StartCoroutine(WalkBird());
        StartCoroutine(RotateBird());
        BirdPecking.speed = Random.Range(0.4f, 1.6f);
    }

    private void Start()
    {
        canRotate = true;
        canMove = true;
    }
}