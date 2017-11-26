using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimController : MonoBehaviour
{
    public GameObject slim;
    public float moveSpeed;
    [HideInInspector]
    public int faceRight = -1;
    [HideInInspector]
    public bool canFlip = true;
    [HideInInspector]
    public bool caught = false;
    public float damage;
    float flipTime = 5.0f;
    float nextFlip = 1.0f;
    Rigidbody2D rb;

    private PlayerController pc;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        faceRight = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb != null && slim!=null)
        {
            slim.transform.position = rb.transform.position; ;
        }
        if (GetComponentInChildren<EnemyHealth>() == null)
        {
            if (pc != null)
            {
                pc.setspeed(new Vector2(0, 0));
                pc.caught = false;
            }
            Destroy(gameObject);
        }
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


    void flipFacing()
    {
        float facingX = transform.localScale.x;
        facingX *= -1;
        transform.localScale = new Vector3(facingX, transform.localScale.y, transform.localScale.z);
        faceRight = -faceRight;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pc = collision.gameObject.GetComponent<PlayerController>();
            pc.setspeed(rb.velocity);
            pc.caught = true;
            canFlip = false;
        }
    }
}

