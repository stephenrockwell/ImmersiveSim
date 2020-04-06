using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool canJump;
    public float jumpHeight = 3f;
    private int jumpsLeft;
    public int extraJumps;

    Vector3 velocity;
    bool isGrounded;

    void Start(){
        jumpsLeft = extraJumps;
    }
    void Update()
    {
        if(isGrounded){
            jumpsLeft = extraJumps;
        }
        if(jumpsLeft > 0){
            canJump = true;
        }
        else{
            canJump = false;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



        if(Input.GetButtonDown("Jump") && canJump){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpsLeft--;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
