using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool finished = false;

    public bool immobile = false;
    public float jumpForce = 2f;

    public float mvtSpeed = .5f;

    public bool isGrounded = false;
    public Rigidbody2D rb;
    private Animator playerAnimator;
    private bool facingRight;
    private readonly int playerSpeedID = Animator.StringToHash("PlayerSpeed");
	private readonly int onGroundID = Animator.StringToHash("OnGround");
	private readonly int hurtID = Animator.StringToHash("Hurt");

    public bool canFlip = false;

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
        if(!finished && !immobile) {
            if(Input.GetKey("space") && isGrounded) {
                rb.velocity += new Vector2(0, jumpForce) * Time.deltaTime * 100;
            }
            if(Input.GetKey("a") && rb.velocity.x > -5) {
                moveLeft();
            }
            
            if(Input.GetKey("d") && rb.velocity.x < 5) {
                moveRight();
            }

            if (Input.GetKey("q") && canFlip){
                playerAnimator.Play("Hurt", 0, 0.5f);
                GetComponent<Rigidbody2D>().gravityScale *= -1;
                canFlip = false;
                FlipPlayerV();
            }
        }
        
    }

    public void defeatPlayer(){
        playerAnimator.SetTrigger(hurtID);
    }

    public void moveLeft() {
        rb.velocity += new Vector2(-mvtSpeed, 0) * Time.deltaTime * 100;
                if (facingRight)
                {
                    FlipPlayerH();
                }
    }

    public void moveRight() {
        rb.velocity += new Vector2(mvtSpeed, 0) * Time.deltaTime * 100;
            if (!facingRight)
            {
                FlipPlayerH();
            }
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
}