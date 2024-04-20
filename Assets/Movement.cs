using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce = 2f;

    public float mvtSpeed = .5f;

    public bool isGrounded = false;
    public Rigidbody2D rb;

    void InputHandler() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        
        if(Input.GetKey("space") && isGrounded) {
            rb.velocity += new Vector2(0, jumpForce) * Time.deltaTime * 100;
        }
        if(Input.GetKey("a") && rb.velocity.x > -5) {
            // if(!isGrounded && rb.velocity.x > 0) {
            //     rb.velocity = new(0, rb.velocity.y);
            // }
            rb.velocity += new Vector2(-mvtSpeed, 0) * Time.deltaTime * 100;
        }
        
        if(Input.GetKey("d") && rb.velocity.x < 5) {
            // if(!isGrounded && rb.velocity.x <  0) {
            //     rb.velocity = new(0, rb.velocity.y);
            // }
            rb.velocity += new Vector2(mvtSpeed, 0) * Time.deltaTime * 100;;
        }
    }

    void OnCollisionStay2D(Collision2D obj) {
            if (obj.gameObject.layer == 3) {
                isGrounded = true;
            }
    }

    void OnCollisionExit2D(Collision2D obj) {
            if (obj.gameObject.layer == 3) {
                isGrounded = false;
            }
    }
}