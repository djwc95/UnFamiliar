using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCartPush : MonoBehaviour
{
    private Animator animator;
    private bool canPush = false;

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canPush= true;
    }

    private void OnTriggerExit(Collider other)
    {
        canPush= false;
    }

    private void Update()
    {
        if (canPush && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Push");
            canPush= false;
        }
    }
}
