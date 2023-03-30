using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RascalAnimations : MonoBehaviour
{
    //public bool running = false;
    //public bool walking = false;
    //public bool right;

    public PlayerMovement2 pm2;
    public Animator rascalAnimator;
    private bool randRoll;

    public GameObject rascal;

    public float countDown = 0.25f;
    private float fullCount = 0.25f;

    private void Start()
    {
        rascalAnimator= GetComponent<Animator>();
        rascal = this.gameObject;

        rascalAnimator.SetBool("walking", false); //set us to idle by default
        rascalAnimator.SetBool("running", false);
    }
    public void Update()
    {
        WalkCheck();
        RunCheck();
    }

    public void WalkCheck()
    {
        if (pm2.movementLocked == true) // if our movement is locked, then we are obviously idle
        {
            rascalAnimator.SetBool("walking", false);
            rascalAnimator.SetBool("running", false);
            IdleRoll(); //roll to see which idle animation we play
        }
        if (pm2.groundedPlayer)
        {
            if (pm2.move.x > 0) // we are walking to the right
            {
                rascalAnimator.SetBool("walking", true);
                rascalAnimator.SetBool("right", true);
                countDown = fullCount; //we're moving, reset the cooldown of idle anim
            }
            else if (pm2.move.x < 0) // we are walking to the left
            {
                rascalAnimator.SetBool("walking", true);
                rascalAnimator.SetBool("right", false);
                countDown = fullCount; //we're moving, reset the cooldown of idle anim
            }
            else if (pm2.move.x == 0) //we are not walking, thus idle 
            {
                rascalAnimator.SetBool("walking", false);
                rascalAnimator.SetBool("running", false);
                countDown -= Time.deltaTime; // small buffer to keep animations smooth
                if (countDown <= 0)
                {
                    IdleRoll(); // roll to see which idle anim we play
                }
            }
        }
    }
    
    public void RunCheck()
    {
        if (pm2.move.x >= 2.1f) // if our speed is over the walk threshold, then we are running
        {
            rascalAnimator.SetBool("running", true);
            rascalAnimator.SetBool("walking", false);
        }
        else if (pm2.move.x <= -2.1f) // if our speed is over the walk threshold in a negtative direction, then we are running
        {
            rascalAnimator.SetBool("running", true);
            rascalAnimator.SetBool("walking", false);
        }
        else if (pm2.move.x < 2.1 && pm2.move.x > -2.1) // if we are below the run threshold, we no longer play run animation
        {
            rascalAnimator.SetBool("running", false);
        }
    }
    
    public void TurnCheck()
    {
        
    }

    public void IdleRoll()
    {
        randRoll = UnityEngine.Random.value > 0.5;
        if (randRoll)
        {
            rascalAnimator.SetBool("randRoll", true);
        }
        else if (!randRoll)
        {
            rascalAnimator.SetBool("randRoll", false);
        }
        
    }
}
