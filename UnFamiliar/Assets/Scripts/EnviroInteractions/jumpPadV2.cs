using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPadV2 : MonoBehaviour
{
    public bool canBoost = false;
    public PlayerMovement2 pm2;

    public float bigJumpHeight;
    public float smallJumpHeight;
    public float bufferTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canBoost= true;
            pm2.verticalVelocity = smallJumpHeight; // increase the player's y position in the movement script by the value we set in unity
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(JumpCool());
        }
    }

    private void Update()
    {
        if (canBoost && Input.GetKeyDown(KeyCode.Space))
        {
            pm2.verticalVelocity = bigJumpHeight;
        }
    }

    IEnumerator JumpCool()
    {
        yield return new WaitForSeconds(bufferTime);
        canBoost = false;
    }
}
