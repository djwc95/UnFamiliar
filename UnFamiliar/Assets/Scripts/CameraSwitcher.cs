using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] vcams;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SwitchCams();
        }
    }

    public void SwitchCams()
    {
        vcams[0].enabled = false;
        vcams[1].enabled = true;
    }
}
