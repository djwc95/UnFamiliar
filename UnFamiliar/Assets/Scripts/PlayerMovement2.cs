using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using UnityEngine.UI;
//using static UnityEditor.PlayerSettings;
using Unity.Burst.CompilerServices;

public class PlayerMovement2 : MonoBehaviour
{
    // a fix to the weird character controller v1
    // minimal air control
    public GroundChecker groundChecker;

    public CharacterController controller;
    public float verticalVelocity;
    public float groundedTimer;        // to allow jumping when going down ramps
    public float baseSpeed;
    public float speed;
    public float jumpHeight = 1.75f;
    private float gravity = 9.8f;
    public float pushForce = 2f;
    
    public bool movementLocked;
    public bool canJump = true;
    public bool groundedPlayer;

    public Vector3 move;

    public quaternion right = Quaternion.Euler(0f, 0f, 0f);
    public quaternion left = Quaternion.Euler(0f, 180f, 0f); // changing directions
    public float rotationSpeed = .01f;

    //=======================Stamina system==========================
    public float stamina = 50f;
    private float staminaConsumption = 10f;
    private float rechargeRate = 7.5f;
    private float maxStamina = 50f;
    public Slider staminaBar;

    //======================= Rotate Cat=============================
    public GameObject carModel;
    public Transform raycastPoint; 
    private RaycastHit hit;

    public float xDirect;
    private float zLock;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        movementLocked= false;
        controller = gameObject.GetComponent<CharacterController>();
        staminaBar.maxValue = 50f;
    }

    public void LockMovement()
    {
        movementLocked = true;
    }

    public void UnLockMovement()
    {
        movementLocked = false;
    }

    void Update()
    {
        if (movementLocked == true)
        {
            return;
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            groundedTimer = 0.4f; // small buffer to allow jumping on ramps (unlike v1)
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime; // decrease unitl we're back at 0 and grounded again
        }

        // slam into the ground
        if (groundedPlayer && verticalVelocity < 0)
        {
            // hit ground
            verticalVelocity = 0f;
        }

        // constant gravity keeps us pulled down when going down ramps
        verticalVelocity -= gravity * Time.deltaTime;

        
        move = new Vector3(Input.GetAxis("Horizontal"), 0, 0); //move only left/right

        move *= speed; // adjust speed in unity

        // allow jump as long as the player is on the ground
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                // must have been grounded recently to allow jump ,aka coyote time
                if (groundedTimer > 0)
                {
                    // no more jumps until we land
                    groundedTimer = 0;

                    // Physics dynamics formula for calculating jump up velocity based on height and gravity
                    verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravity);
                }
            }
        }

        move.y = verticalVelocity;

        if (transform.position.z != zLock) //if we ever deviate from our z position, push us back
        {
            move.z = (zLock - transform.position.z) * 25f;
        }

        //============================ Sprinting and Stamina ==============================
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = 3.75f; //sprint button
            stamina -= staminaConsumption * Time.deltaTime; // drain stamina each second
        }
        else
        {
            speed = baseSpeed; // return us back to our base speed

            xDirect = Input.GetAxis("Horizontal") * speed;
            if(stamina < maxStamina)
            {
                StartCoroutine(StaminaRecharge());
            }
        }
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        staminaBar.value = stamina;

       

        //============================== ROTATE CAT TO MATCH THE TERRAIN =========================
        // Find location and slope of ground below us
        Physics.Raycast(raycastPoint.position, Vector3.down, out hit, 1);    // Keep at specific height above terrain

        // Rotate to align with terrain
        Quaternion target = Quaternion.Euler(0, 0, groundChecker.groundSlopeAngle);

        if (!groundedPlayer) // how we rotate while airborne
        {
            if (move.x > 0)
            {
                target = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
            else if (move.x < 0)
            {
                target = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
        }

        if (move.x < 0) // moving left
        {
            if (groundChecker.rearSlopeHit.distance > groundChecker.frontSlopeHit.distance)
            {
                target = Quaternion.Euler(0, 180, -groundChecker.groundSlopeAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
            else if (groundChecker.rearSlopeHit.distance < groundChecker.frontSlopeHit.distance)
            {
                target = Quaternion.Euler(0, 180, groundChecker.groundSlopeAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
            else
            {
                target = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
        }
        else if (move.x > 0) //moving right
        {
            if (groundChecker.rearSlopeHit.distance > groundChecker.frontSlopeHit.distance)
            {
                target = Quaternion.Euler(0, 0, groundChecker.groundSlopeAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
            else if (groundChecker.rearSlopeHit.distance < groundChecker.frontSlopeHit.distance)
            {
                target = Quaternion.Euler(0, 0, -groundChecker.groundSlopeAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
            else
            {
                target = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10);
            }
        }

        controller.Move(move * Time.deltaTime); // always call at the end so everything else is already lined up properly

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) //dont push a kinematic body
        {
            return;
        }
        Vector3 pushDir = new Vector3(hit.moveDirection.x, hit.moveDirection.y, 0); //else, push it
        body.velocity = pushDir * pushForce;
    }

    public IEnumerator StaminaRecharge()
    {
        yield return new WaitForSeconds(1.75f);
        stamina += rechargeRate * Time.deltaTime;
    }
}