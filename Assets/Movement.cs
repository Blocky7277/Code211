using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using static UnityEngine.UI.Image;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    public LayerMask IgnoreMe;
    public float mvtSpeed = .5f;

    public bool isGrounded = false;
    public Rigidbody2D rb;
    public Vector2 playerVelocity;
    public Boolean justTeleported = false;
    public float teleportTimer;
    public bool pressingLeft = false;
    public bool pressingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!justTeleported)
        {
            if (Input.GetKey("space") && isGrounded)
            {
                rb.velocity += new Vector2(0, jumpForce) * Time.deltaTime * 100;
            }
        }
        else
        {
            if (teleportTimer >= 0.6)
            {
                teleportTimer = 0;
                justTeleported = false;
            }
            else
            {
                Debug.Log(Time.deltaTime);
                teleportTimer += Time.deltaTime;
            }
        }
        if (Input.GetKey("a") && Mathf.Abs(rb.velocity.x) <= Mathf.Abs(mvtSpeed * Time.deltaTime * 50))
            {
                // if(!isGrounded && rb.velocity.x > 0) {
                //     rb.velocity = new(0, rb.velocity.y);
                // }
                rb.velocity += new Vector2(-mvtSpeed, 0) * Time.deltaTime * 50;
            }
        if (pressingLeft && Mathf.Abs(rb.velocity.x) <= Mathf.Abs(mvtSpeed * Time.deltaTime * 50))
        {
            // if(!isGrounded && rb.velocity.x > 0) {
            //     rb.velocity = new(0, rb.velocity.y);
            // }
            rb.velocity += new Vector2(-mvtSpeed, 0) * Time.deltaTime * 50;
        }


        if (Input.GetKey("d") && Mathf.Abs(rb.velocity.x) <= Mathf.Abs(mvtSpeed * Time.deltaTime * 50))
            {
                // if(!isGrounded && rb.velocity.x <  0) {
                //     rb.velocity = new(0, rb.velocity.y);
                // }
                rb.velocity += new Vector2(mvtSpeed, 0) * Time.deltaTime * 50;
            }
        if (pressingRight && Mathf.Abs(rb.velocity.x) <= Mathf.Abs(mvtSpeed * Time.deltaTime * 50))
        {
            // if(!isGrounded && rb.velocity.x <  0) {
            //     rb.velocity = new(0, rb.velocity.y);
            // }
            rb.velocity += new Vector2(mvtSpeed, 0) * Time.deltaTime * 50;
        }
        playerVelocity = GetComponent<Rigidbody2D>().velocity;
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.layer == 1)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.layer == 1)
        {
            isGrounded = false;
        }
    }

    public void clickedLeft()
    {
        pressingLeft = true;
    }
    public void clickedRight()
    {
        pressingRight = true;
    }
    public void letGoLeft()
    {
        pressingLeft = false;
    }
    public void letGoRight()
    {
        pressingRight = false;
    }

    void checkJump()
    {
        Debug.Log("iebra");
    }

    public void jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1.25f, ~IgnoreMe);
        if (hit.collider != null)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
