using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabbitController : MonoBehaviour {

    [HideInInspector]public Animator anim;
    public float moveSpeed;   //normal movespeed
    public float attackSpeed;   // speed when chasing character
    public GameObject rabbit;
    [HideInInspector]public int faceRight = -1;   //current facing
    [HideInInspector]public bool canFlip = true;   // judge if it can flip
    float flipTime = 5.0f;   //time between two flips
    float nextFlip = 1.0f;   //after this time  you can flip
    Rigidbody2D rb;
    public Rigidbody2D ice;
    public Transform iceSpawn;

    // Parameters to check whether on ground
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    private EnemyRabbitDamage erd;
    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        erd = GetComponentInChildren<EnemyRabbitDamage>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Time.time > nextFlip && canFlip || onGround == false)
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
        if (other == null || erd.playerKilled == true)  return;
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
        if(other == null || erd.playerKilled == true)
        {
            return;
        }
        else if(other.tag == "Player")
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

    public void MonsterIce()
    {
        Instantiate(ice, iceSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
