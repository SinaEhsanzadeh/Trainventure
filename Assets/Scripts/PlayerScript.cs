using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//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
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
        CheckIfGrounded();
        PlayerMove();
        PlayerJump();
    }
    void FixedUpdate()
    {
        
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
        
        if (Physics2D.OverlapArea(new Vector2(groundCheckPosition.position.x - 0.3f, groundCheckPosition.position.y), new Vector2(groundCheckPosition.position.x + 0.3f, groundCheckPosition.position.y) , groundLayer))
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
