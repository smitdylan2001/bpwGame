using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidbody;
    bool isGrounded;
    float disstanceToTheGround;
    int counter = 0;
    public bool isBig;
    float playerScale = 1;
    Vector3 temp;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        disstanceToTheGround = GetComponentInChildren<Collider>().bounds.extents.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, disstanceToTheGround + 0.1f);
    }

    void Start()
    {
        isBig = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void Update()
    {
        Movement();
        CheckMoonJump();
        Resize();

    }

    private void FixedUpdate()
    {
    }

    private void Movement()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 moveDir = vert * transform.forward + hor * transform.right;
        if (isGrounded == true)
        {
            rigidbody.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime * moveSpeed);
        }
        else
        {
            Vector3 temp = rigidbody.velocity;
            rigidbody.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime * moveSpeed);
        }
    }

    private void CheckMoonJump()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Physics.gravity = new Vector3(Physics.gravity.x, -1, Physics.gravity.z);
            if (Input.GetKeyDown(KeyCode.E))
            {
                rigidbody.AddForce(0, 150, 0);
            }

        }
        else
        {
            Physics.gravity = new Vector3(Physics.gravity.x, -9.8f, Physics.gravity.z);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rigidbody.AddForce(0, -400, 0);
        }
    }

    private void Resize()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            isBig = !isBig;
        }

        if (isBig == true && playerScale < 1)
        {
            playerScale += 0.01f;
        }
        if (isBig == false && playerScale > 0.4)
        {
                playerScale -= 0.01f;
        }
        transform.localScale = new Vector3(playerScale, playerScale, playerScale);

    }
}
