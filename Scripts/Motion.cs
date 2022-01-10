using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Motion : MonoBehaviour
{
    public float speed;
    public float modifiedSpeed;
    public float jumpForce;
    public float sprintJump;
    public Camera normalCam;
    public LayerMask ground;
    public Transform groundDetector;
    public AudioSource walkingPlayer;
    public AudioClip walkingSound;


    private float baseFOV;
    private float sprintFOVModifier = 1.25f;

    private Rigidbody rig;
        
  
    void Start()
    {
        baseFOV = normalCam.fieldOfView;
        Camera.main.enabled = false;
        rig = GetComponent<Rigidbody>();
        walkingPlayer.clip = walkingSound;
        walkingPlayer.volume = 0.1f;

    }

    void FixedUpdate()
    {
            
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

            
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKey(KeyCode.Space);

            
        bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.2f, ground);
        bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && vMove > 0 && !isJumping && isGrounded;

            
        Vector3 t_direction = new Vector3(hMove, 0, vMove);
        t_direction.Normalize();

            
        if(isJumping)
        {
            if (isSprinting)
            {
                rig.AddForce(Vector3.up * sprintJump * jumpForce);
                rig.AddForce(Vector3.forward * sprintJump * jumpForce);
            }
            else
            {
                rig.AddForce(Vector3.up * jumpForce);
            }
        }

        float t_adjustedSpeed = speed;
        if(isSprinting)
        {
            t_adjustedSpeed = modifiedSpeed * speed;
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
        }
            
        else
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
        }
            
        if(isGrounded && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if(!walkingPlayer.isPlaying)
                walkingPlayer.Play();
        }
        else
        {
            walkingPlayer.Stop();
        }
        Vector3 targetVelocity = transform.TransformDirection(t_direction) * t_adjustedSpeed * Time.deltaTime;
        targetVelocity.y = rig.velocity.y;
        rig.velocity = targetVelocity;
    }

}
