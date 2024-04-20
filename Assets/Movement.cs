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
    private Animator playerAnimator;
    private bool facingRight;
    private readonly int playerSpeedID = Animator.StringToHash("PlayerSpeed");
	private readonly int onGroundID = Animator.StringToHash("OnGround");
	private readonly int flipGravID = Animator.StringToHash("Hurt");
	private readonly int hurtID = Animator.StringToHash("Hurt");

    // Start is called before the first frame update
    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Always checking if player on Ground or not
		playerAnimator.SetBool(onGroundID, isGrounded);
		// Always setting the Player Speed to the Animator - Idle if Horizontal PlayerSpeed < 0.05f
		playerAnimator.SetFloat(playerSpeedID, Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
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
            if (facingRight)
            {
                FlipPlayerH();
            }
        }
        
        if(Input.GetKey("d") && rb.velocity.x < 5) {
            // if(!isGrounded && rb.velocity.x <  0) {
            //     rb.velocity = new(0, rb.velocity.y);
            // }
            rb.velocity += new Vector2(mvtSpeed, 0) * Time.deltaTime * 100;
            if (!facingRight)
            {
                FlipPlayerH();
            }
        }

        if (Input.GetKey("q") && isGrounded){
            playerAnimator.Play("Hurt", 0, 0.5f);
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            FlipPlayerV();
        }
    }

    public void defeatPlayer(){
        playerAnimator.SetTrigger(hurtID);
    }
    private void FlipPlayerH()
	{
		facingRight = !facingRight; // FacingRight becomes the opposite of the current value.
		transform.Rotate(0f, 180f, 0f);
	}
    private void FlipPlayerV()
	{
		transform.Rotate(xAngle: 180f, 0f, 0f);
        jumpForce *= -1;
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