using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCooler : MonoBehaviour
{
    public Animator animator;
    public bool canOpen = true;
    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
    }

    public IEnumerator Cooldown()
    {
        canOpen= false;
        yield return new WaitForSeconds(2);
        canOpen= true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            animator.SetTrigger("Open");
            StartCoroutine(Cooldown());
        }
    }
}
