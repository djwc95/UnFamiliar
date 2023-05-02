using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBath : MonoBehaviour
{
    public Animator BirdBathing;
    //public PlayerMovement2 pm2;
    public MoveAtoB moveAtoB;
    public float waitTime = 1.25f;
    //public MoveAtoB moveInReverse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(SpookBird());
            BirdBathing.SetTrigger("Spook");
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
        moveAtoB.Move();
        StartCoroutine(DestroyOverTime());
    }
}