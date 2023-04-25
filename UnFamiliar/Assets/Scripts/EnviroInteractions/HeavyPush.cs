using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPush : MonoBehaviour
{
    public PlayerMovement2 pm2;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pm2.pushForce = .25f;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pm2.pushForce = 2f;
        }
    }
}
