using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciFiPlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6;
    //gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0;

    //Camera and rotation
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    //animation
    public Animator animator;

    //Jump
    public float jumpForce = 3.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("Shoot");
        }

        Move();
        Rotate();

        // animator.SetBool("Shoot", false);
    }

    private void Move()
    {
        float horisontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            Vector3 move = transform.forward * verticalMove + transform.right * horisontalMove + transform.up * jumpForce;
            characterController.Move(speed * Time.deltaTime * move /*+ gravityMove * Time.deltaTime*/);
            animator.SetBool("Jump", true);
        }
        else
        {
            Vector3 move = transform.forward * verticalMove + transform.right * horisontalMove;
            characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
            animator.SetBool("Jump", false);
        }

        //Vector3 move = transform.forward * verticalMove + transform.right * horisontalMove;
        //characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);

        //animator.SetBool("isWalking", verticalMove != 0 || horisontalMove != 0);
        animator.SetBool("isWalking", verticalMove > 0);
        animator.SetBool("Backward", verticalMove < 0);
        animator.SetBool("StrafeLeft", horisontalMove < 0);
        animator.SetBool("StrafeRight", horisontalMove > 0);
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180)
        {
            currentRotation.x -= 360;
            currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
            cameraHolder.localRotation = Quaternion.Euler(currentRotation);
        }

    }
}
