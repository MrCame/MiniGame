using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemonController : MonoBehaviour {

    public float moveSpeed;
    [HideInInspector]
    public int faceRight = 1;
    [HideInInspector]
    public bool canFlip = true;
    public float damage;
    float flipTime = 5.0f;
    float nextFlip = 1.0f;
    Rigidbody2D rb;
    private PlayerHealth ph;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ph = other.gameObject.GetComponent<PlayerHealth>();
            ph.takeDamage(damage);
        }
    }
}
