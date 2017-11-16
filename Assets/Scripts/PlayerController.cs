using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
    public float movespeed;
    public float jumpheight;
    public bool moveright;
    public bool moveleft;
    public bool jump;

    // Shoot Parameters
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f; //the frequency of shoot 
    private float nextFire;

    // Parameters to check whether on ground
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    [HideInInspector]
    public bool facingRight;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

    }

    // Check whether on ground
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
        
    void Update () {

        // Control From keyboard A:shoot, space: jump, left and right arrow: control
        if (Input.GetKey (KeyCode.LeftArrow)) {
            rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
            facingRight = false;

        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            rb.velocity = new Vector2 (movespeed, rb.velocity.y);
            facingRight = true;

        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
            }
        }

        if (Input.GetKey (KeyCode.A) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        // Control From Touch
        if (moveright) {
            rb.velocity = new Vector2 (movespeed, rb.velocity.y);
            facingRight = true;
        }

        if (moveleft) {
            rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
            facingRight = false;
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
}
