using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int damage;
    private GameObject player;
    private GameObject gamecontroller;
    private GameController gc;
    private Rigidbody2D rb;
    private Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gamecontroller = GameObject.FindGameObjectWithTag("GameController");
        gc = gamecontroller.GetComponent<GameController>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        anim.speed = 1.0f;
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (player.transform.position.x - rb.transform.position.x <= 3 && player.transform.position.x - rb.transform.position.x > 0 &&
            player.transform.position.y == rb.transform.position.y  && gc.face==-1)
            gc.takedamage(damage);

	}

   
}
