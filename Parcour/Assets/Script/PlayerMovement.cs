using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed;
    public Rigidbody rigidbody;
    bool isGrounded;
    float disstanceToTheGround;
    bool isBig;
    float playerScale = 1;
    Vector3 temp;
    Vector3 jump;
    public float jumpForce = 2.0f;
    bool moonjump;
    bool moonjump2;
    Vector3 moveDir;


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
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            isBig = !isBig;
        }
        Resize();

        if (Input.GetKey(KeyCode.E))
        {
            moonjump = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                moonjump2 = true;

            }

        }
        else
        {
            moonjump = false;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rigidbody.AddForce(0, -400, 0);
        }
    }

    private void FixedUpdate()
    {
        CheckMoonJump();
        rigidbody.MovePosition(transform.position + moveDir.normalized * moveSpeed *Time.fixedDeltaTime * playerScale);
    }


    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void Movement()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        

        moveDir = vert * transform.forward + hor * transform.right;
        Debug.Log(playerScale) ;
       
       
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rigidbody.AddForce(jump * jumpForce * playerScale, ForceMode.Force);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }
        else 
        {
            moveSpeed = 6;
        }

    }

    private void CheckMoonJump()
    {
        if (moonjump)
        {
            Physics.gravity = new Vector3(Physics.gravity.x, -3, Physics.gravity.z);
            if (moonjump2)
            {
                rigidbody.AddForce(0, 300, 0);
                isGrounded = false;
                moonjump2 = false;
            }

        }
        else
        {
            Physics.gravity = new Vector3(Physics.gravity.x, -13f, Physics.gravity.z)* playerScale;
            moonjump = false;
        }

        
    }

    private void Resize()
    {

        if (isBig == true && playerScale < 1)
        {
            playerScale += (1f*Time.deltaTime);

            
        }
        if (isBig == false && playerScale > 0.4)
        {
            playerScale -= (1f * Time.deltaTime);

        }
        transform.localScale = new Vector3(playerScale, playerScale, playerScale);

    }
}
