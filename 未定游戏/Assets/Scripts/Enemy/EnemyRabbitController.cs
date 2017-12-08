using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabbitController : MonoBehaviour {

    Animator anim;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    public float moveSpeed;   //normal movespeed
    public float attackSpeed;   // speed when chasing character
    public GameObject rabbit;
    [HideInInspector]public int faceRight = -1;   //current facing
    [HideInInspector]public bool canFlip = true;   // judge if it can flip
    float flipTime = 5.0f;   //time between two flips
    float nextFlip = 1.0f;   //after this time  you can flip
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if ((Time.time > nextFlip && canFlip) || onGround == false)
        {
            flipFacing();
            nextFlip = Time.time + flipTime;
        }
        if (canFlip)
        {
            rb.velocity = new Vector2(moveSpeed*faceRight, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null || onGround==false) return;
        if (other.tag == "Player")
        {
            anim.speed = 3;
            if (faceRight == 1 && transform.position.x > other.transform.position.x)
                flipFacing();
            else if (faceRight == -1 && transform.position.x < other.transform.position.x)
                flipFacing();
            canFlip = false;
            rb.velocity = new Vector2(attackSpeed * faceRight, 0);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (onGround == false)
            return;
        if (other.tag == "Player")
        {
            anim.speed = 3;
            if (faceRight == 1 && transform.position.x > other.transform.position.x)
                flipFacing();
            else if (faceRight == -1 && transform.position.x < other.transform.position.x)
                flipFacing();
            canFlip = false;
            rb.velocity = new Vector2(attackSpeed * faceRight, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            return;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.speed = 1.0f;
            canFlip = true;
        }
    }

    void flipFacing()
    {
        if (rabbit == null) return;
        float facingX = rabbit.transform.localScale.x;
        facingX *= -1;
        rabbit.transform.localScale = new Vector3(facingX, rabbit.transform.localScale.y, rabbit.transform.localScale.z);
        faceRight = -faceRight;
    }
}
