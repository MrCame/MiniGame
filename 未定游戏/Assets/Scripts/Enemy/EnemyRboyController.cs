using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRboyController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject rboy;
    [HideInInspector]public int faceRight = 1;
    [HideInInspector]public bool canFlip = true;
    float flipTime = 5.0f;
    float nextFlip = 1.0f;
    Rigidbody2D rb;
    public Rigidbody2D ice;
    public Transform iceSpawn;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponentInChildren<EnemyHealth>() == null)
            Destroy(gameObject);
        rboy.transform.position = rb.transform.position;  //不加这个就会漂移？？？
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
        if (rboy == null) return;
        float facingX = transform.localScale.x;
        facingX *= -1;
        transform.localScale = new Vector3(facingX, transform.localScale.y, transform.localScale.z);
        faceRight = -faceRight;
        
    }

    public void MonsterIce()
    {
       Instantiate(ice, iceSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}