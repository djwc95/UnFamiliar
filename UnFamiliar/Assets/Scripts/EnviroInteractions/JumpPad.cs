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
    public AudioClip smallJumpAudioClip;
    public AudioClip bigJumpAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            jumpNum++;
            if (jumpNum < 3)
            {
                StartCoroutine(SmallJump());
            }
            else if (jumpNum >= 3)
            {
                StartCoroutine(BigJump());
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

    IEnumerator BigJump()
    {
        yield return new WaitForSeconds(.05f);
        playerMovement2.canJump = false;
        audioSource.clip = bigJumpAudioClip;
        audioSource.Play();
        playerMovement2.verticalVelocity = bigJumpHeight; // increase the player's y position in the movement script by the value we set in unity
        StartCoroutine(JumpCool());
    }
    IEnumerator SmallJump()
    {
        yield return new WaitForSeconds(.05f);
        playerMovement2.canJump = false;
        audioSource.clip = smallJumpAudioClip;
        audioSource.Play();
        playerMovement2.verticalVelocity = smallJumpHeight; // increase the player's y position in the movement script by the value we set in unity
        StartCoroutine(JumpCool());
    }
}
