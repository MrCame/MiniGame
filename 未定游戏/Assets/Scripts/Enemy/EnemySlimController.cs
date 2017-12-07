using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimController : MonoBehaviour
{
    public float moveSpeed;   //normal movespeed
    public float attackSpeed;   // speed when chasing character
    public GameObject slim;
    [HideInInspector]
    public int faceRight = -1;   //current facing
    [HideInInspector]
    public bool canFlip = true;   // judge if it can flip
    float flipTime = 5.0f;   //time between two flips
    float nextFlip = 1.0f;   //after this time  you can flip
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        slim.transform.position = gameObject.transform.position;
        if (Time.time > nextFlip && canFlip)
        {
            flipFacing();
            nextFlip = Time.time + flipTime;
        }
        if (canFlip)
        {
            rb.velocity = new Vector2(moveSpeed * faceRight, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null) return;
        if (other.tag == "Player")
        {
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
        if (other.tag == "Player")
        {
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
            canFlip = true;
        }
    }

    void flipFacing()
    {
        if (slim == null) return;
        float facingX = slim.transform.localScale.x;
        facingX *= -1;
        slim.transform.localScale = new Vector3(facingX, slim.transform.localScale.y, slim.transform.localScale.z);
        faceRight = -faceRight;
    }
}
