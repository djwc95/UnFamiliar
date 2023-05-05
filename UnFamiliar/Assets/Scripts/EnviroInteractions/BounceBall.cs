using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    private Animator animator;
    private bool canTrigger = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTrigger= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTrigger = true;
        }
    }

    private void Update()
    {
        if (canTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("KickBall");
                canTrigger= false;
            }
        }
    }
}
