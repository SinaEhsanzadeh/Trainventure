using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerBody = target.gameObject.GetComponent<Rigidbody2D>();
            playerBody.gravityScale = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, 5f);
            }else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, -5f);
            }
            else
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, 0f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerBody = target.gameObject.GetComponent<Rigidbody2D>();
            playerBody.gravityScale = 3f;
        }
    }
}
