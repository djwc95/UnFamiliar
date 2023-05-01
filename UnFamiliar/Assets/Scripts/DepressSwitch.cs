using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressSwitch : MonoBehaviour
{
    public Animator switchPress;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchPress.SetTrigger("Depress");
            Debug.Log("pillar depressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchPress.SetTrigger("Expand");
            Debug.Log("pillar expanded");
        }
    }
}
