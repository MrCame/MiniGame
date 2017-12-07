using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimDamage : MonoBehaviour {

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsGround;
    private bool hitWall;
    [HideInInspector]
    public PlayerController pc;
    private EnemySlimController esc;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        esc = GetComponentInParent<EnemySlimController>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsGround); //check if the player is caught to the wall
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.position = wallCheck.position;
            pc = collision.gameObject.GetComponent<PlayerController>();
            pc.caught = true;
            pc.setspeed(new Vector2(esc.faceRight*1.0f,0));
            esc.canFlip = false;
            if (hitWall == true)
            {
                PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
                Debug.Log("hit");
                ph.takeDamage(100);
                esc.canFlip = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.position = wallCheck.position;
            pc = collision.gameObject.GetComponent<PlayerController>();
            pc.caught = true;
            pc.setspeed(new Vector2(esc.faceRight * 1.0f, 0));
            esc.canFlip = false;
            if(hitWall== true)
            {
                PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
                Debug.Log("hit");
                ph.takeDamage(100);
                esc.canFlip = true;
            }
        }
    }

}
