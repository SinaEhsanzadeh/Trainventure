using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public Transform groundCheckPosition;
    public Transform leftCheckPosition;
    public Transform rightCheckPosition;
    public Transform topCheckPosition;

    public LayerMask groundLayer;

    private bool jumped;
    private bool isGrounded;

    public float jumpPower = 10f;
    
    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        CheckIfGrounded();
        PlayerMove();
        PlayerJump(); 
    }

    

    void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }
    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);

                isGrounded = false;

            }
        }
    }


    void CheckIfGrounded()
    {
        
        if (Physics2D.OverlapArea(new Vector2(groundCheckPosition.position.x - 0.3f, groundCheckPosition.position.y - 0.01f), new Vector2(groundCheckPosition.position.x + 0.3f, groundCheckPosition.position.y + 0.01f) , groundLayer))
        {
            if (jumped)
            {
                jumped = false;
            }
            
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }
}
