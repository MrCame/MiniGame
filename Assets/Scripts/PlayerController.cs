using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
    public float movespeed = 3.0f;
    public float jumpheight = 5.0f;
    public bool moveright;
    public bool moveleft;
    public bool jump;

    // Parameters to check whether on ground
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    // animations

    private Animator anim;
    private float h;
    [HideInInspector]
    public bool facingRight = true;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Check whether on ground
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
        
    void Update () {

        h = 0;        
        // Control From keyboard A:shoot, space: jump, left and right arrow: control
        if (Input.GetKey (KeyCode.LeftArrow)) {
            h = -1;
            rb.velocity = new Vector2 (-movespeed, rb.velocity.y);

        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            h = 1;
            rb.velocity = new Vector2 (movespeed, rb.velocity.y);
        }

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
        }

        if(h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if(h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // Control From Touch
        if (moveright) {
            rb.velocity = new Vector2 (movespeed, rb.velocity.y);
        }

        if (moveleft) {
            rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
        }

        if (jump)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
            jump = false;
        }
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
}
