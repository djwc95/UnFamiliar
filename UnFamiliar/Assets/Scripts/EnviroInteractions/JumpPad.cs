using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public PlayerMovement2 playerMovement2; //reference the player movement script
    public float bigJumpHeight;
    public float smallJumpHeight;
    public int jumpNum = 0;

    public AudioSource audioSource;
    public AudioClip lowSound;
    public AudioClip highSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            jumpNum++;
            if (jumpNum < 3)
            {
                audioSource.clip = lowSound; //play sound
                audioSource.Play();
                playerMovement2.canJump = false;
                playerMovement2.verticalVelocity = smallJumpHeight; // increase the player's y position in the movement script by the value we set in unity
                StartCoroutine(JumpCool());
            }
            else if (jumpNum >= 3)
            {
                audioSource.clip = highSound; //play sound
                audioSource.Play();
                playerMovement2.canJump = false;
                playerMovement2.verticalVelocity = bigJumpHeight; // increase the player's y position in the movement script by the value we set in unity
                StartCoroutine(JumpCool());
            }

        }
    }

    private void Update()
    {
        if (jumpNum >= 3)
        {
            jumpNum = 0;
        }
    }

    public IEnumerator JumpCool()
    {
        yield return new WaitForSeconds(.5f);
        playerMovement2.canJump = true;
    }
}
