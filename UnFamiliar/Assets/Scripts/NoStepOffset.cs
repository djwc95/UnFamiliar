using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoStepOffset : MonoBehaviour
{
    public CharacterController controller;
    public float startValue;

    private void Start()
    {
        //controller = GetComponent<CharacterController>();
        startValue = controller.stepOffset;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StepSwitch")
        {
            controller.stepOffset = 0F;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "StepSwitch")
        {
            controller.stepOffset = startValue;
        }
    }
}
