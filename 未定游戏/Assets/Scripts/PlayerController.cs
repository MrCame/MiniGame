using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
    public float movespeed = 3.0f;
    public float jumpheight = 5.0f;
    public bool TouchJump;

    public float moveForce = 365f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1f; 
    
    // Parameters to check whether on ground
    public Transform groundCheck;
    public Transform camCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    [HideInInspector]
    public bool onGround;
    [HideInInspector]
    public bool focus;
    // animations

    private Animator anim;
    [HideInInspector]
    public float h = 0f;
    public bool TouchGet = false;
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool caught = false;
    [HideInInspector]
    public bool hit = false;   // show if the player is hit
    private int hitback = 0;   //count time when hit

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hit = false;
        caught = false;
    }

    // Check whether on ground
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        focus = Physics2D.OverlapCircle(camCheck.position, groundCheckRadius, whatIsGround);
    }
        
    void Update () {

        // Control From keyboard A:shoot, space: jump, left and right arrow: control
        
        if (!TouchGet) // Control from Touch Not keyboard
        {
            if (Input.GetKey (KeyCode.LeftArrow)) 
                h = -1;
            else if(Input.GetKey (KeyCode.RightArrow))
                h = 1;
            else 
                h = 0;
        }

        if (hit && !caught)
        {
            hitback++;
            if (hitback >= 10)
            {
                hit = false;
                hitback = 0;
            }
        }

        else
        {
            rb.velocity = new Vector2(h * movespeed, rb.velocity.y);
            // Control From keyboard A:shoot, space: jump, left and right arrow: control

            anim.SetFloat("Speed", Mathf.Abs(h));
        }

        if(h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if(h < 0 && facingRight)
            // ... flip the player.
            Flip();

        

        if (Input.GetKey(KeyCode.Space) || TouchJump)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
            TouchJump = false;
        }
        

        // Control From Touch
/*
        if (TouchJump)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
            Jump = false;
        }*/
    }

    void Flip ()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void setspeed(Vector2 speed)
    {
        rb.velocity = speed;
    }
    public void StopControl()
    {
        this.enabled = false;
    }
}
