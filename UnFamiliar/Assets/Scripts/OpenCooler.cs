using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCooler : MonoBehaviour
{
    public Animator animator;
    public bool canOpen = true;
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            animator.SetTrigger("Open");
            StartCoroutine(Cooldown());
        }
    }

    public IEnumerator Cooldown()
    {
        canOpen= false;
        yield return new WaitForSeconds(2);
        canOpen= true;
    }
}
