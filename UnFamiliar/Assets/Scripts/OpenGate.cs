using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] private Animator gate = null;
    CinemachineImpulseSource impulse;
    private bool gateOpened = false;

    private void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Weight") || other.CompareTag("Player")) && gateOpened == false) //player or weight object can open gate
        {
            gate.Play("OpenGate", 0, 0f);
        }

        if (other.CompareTag("Weight"))
        {
            gateOpened = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weight") || (other.CompareTag("Player") && gateOpened == false)) //if no weight, gate closes
        {
            gate.Play("CloseGate", 0, 0f);
            Shake();
        }
        if (other.CompareTag("Weight"))
        {
            gateOpened = false;
        }
    }

    public void Shake()
    {
        impulse.GenerateImpulse();
    }
}