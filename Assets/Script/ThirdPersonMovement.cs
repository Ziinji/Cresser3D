using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using Cinemachine;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    bool isWalking = false;
    bool isRunning = false;
    bool isJumping = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public Vector2 turn;

    // Update is called once per frame

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -10f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            isJumping = true;
            animator.SetTrigger("JumpAnim");
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (isRunning == true)
        {
            animator.SetBool("RunAnim", true);
        }

        if (isRunning == false)
        {
            animator.SetBool("RunAnim", false);
        }

        if (isWalking == true)
        {
            animator.SetBool("WalkAnim", true);
        }

        if (isWalking == false)
        {
            animator.SetBool("WalkAnim", false);
        }


        if (direction.magnitude >= 0.1f)
        {
      
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(moveDir.normalized * speed * 1.2f * Time.deltaTime);
                isWalking = false;
                isRunning = true;

            } else
            {
                //direction.x = cam.transform.position.x;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
                isWalking = true;

            }
          
        } else
        {
            isRunning = false;
            isWalking = false;
        }
    }
}