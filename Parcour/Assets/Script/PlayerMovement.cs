using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidbody;
    public bool isGrounded;
    float disstanceToTheGround;
    public bool isBig;
    float playerScale = 1;
    Vector3 temp;
    public Vector3 jump;
    public float jumpForce = 2.0f;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        disstanceToTheGround = GetComponentInChildren<Collider>().bounds.extents.y;
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, disstanceToTheGround + 0.1f);
    }

    void Start()
    {
        isBig = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    void Update()
    {
        Movement();
        CheckMoonJump();
        if (Input.GetKeyDown(KeyCode.F))
        {
            isBig = !isBig;
        }
    }

    private void FixedUpdate()
    {
        Resize();
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void Movement()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        

        Vector3 moveDir = vert * transform.forward + hor * transform.right;
        if (isGrounded == true)
        {
            rigidbody.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime * playerScale);
        }
        else
        {
            Vector3 temp = rigidbody.velocity;
            rigidbody.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime * playerScale);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rigidbody.AddForce(jump * jumpForce * playerScale, ForceMode.Force);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 20;
        }
        else 
        {
            moveSpeed = 10;
        }

    }

    private void CheckMoonJump()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Physics.gravity = new Vector3(Physics.gravity.x, -3, Physics.gravity.z);
            if (Input.GetKeyDown(KeyCode.E))
            {
                rigidbody.AddForce(0, 300, 0);
                isGrounded = false;

            }

        }
        else
        {
            Physics.gravity = new Vector3(Physics.gravity.x, -13f, Physics.gravity.z)* playerScale;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rigidbody.AddForce(0, -400, 0);
        }
    }

    private void Resize()
    {

        if (isBig == true && playerScale < 1)
        {
            playerScale += 0.05f;

            
        }
        if (isBig == false && playerScale > 0.4)
        {
            playerScale -= 0.05f;

        }
        transform.localScale = new Vector3(playerScale, playerScale, playerScale);

    }
}
