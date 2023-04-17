using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDown : MonoBehaviour
{
    public Animator animator;
    public bool canLower = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canLower)
        {
            animator.SetTrigger("LowerDown");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canLower = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canLower = false;
        }
    }
}
