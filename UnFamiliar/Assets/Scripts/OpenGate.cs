using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] private Animator gate = null;
    CinemachineImpulseSource impulse;

    private void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weight") || other.CompareTag("Player")) //player or weight object can open gate
        {
            gate.Play("OpenGate", 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weight") || other.CompareTag("Player")) //if no weight, gate closes
        {
            gate.Play("CloseGate", 0, 0f);
            Shake();
        }
    }

    public void Shake()
    {
        impulse.GenerateImpulse();
    }
}
