using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumpPads : MonoBehaviour
{
    public PlayerMovement2 pm2;
    public bool setOn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setOn= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setOn = false;
        }
    }
    private void Update()
    {
        if (setOn)
        {
            if (!pm2.groundedPlayer)
            {
                pm2.speed = pm2.baseSpeed * 1.75f;
                Debug.Log("better air control");
            }
        }
    }
}
