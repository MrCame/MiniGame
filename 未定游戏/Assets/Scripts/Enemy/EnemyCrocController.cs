using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCrocController : MonoBehaviour {

    private bool canTurn;
    private int up;
    private Rigidbody2D rb;
    private float nextTurn;
    public float turnTime;
    public float moveSpeed;
    public float damage;
    private EnemyHealth EH;
    public Rigidbody2D ice;
    public Transform iceSpawn;
    // Use this for initialization
    void Start() {
        canTurn = true;
        rb = GetComponent<Rigidbody2D>();
        up = 1;
        nextTurn = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextTurn && canTurn)
        {
            Turn();
            nextTurn = Time.time + turnTime;
        }
        if (canTurn)
        {
            rb.velocity = new Vector2(0, moveSpeed * up);
        }
    }

    void Turn()
    {
        up = -up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D prb = collision.gameObject.GetComponent<Rigidbody2D>();
            prb.AddForce(new Vector2(-3 * prb.velocity.x, 0), ForceMode2D.Impulse);
            PlayerHealth ph = collision.gameObject.GetComponentInParent<PlayerHealth>();
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.hit = true;
            ph.takeDamage(damage);
        }
    }

    public void MonsterIce() {
        EnemyHealth EM = gameObject.GetComponent<EnemyHealth>();
        Rigidbody2D ice = gameObject.GetComponent<Rigidbody2D>();
        if(EM.enemyHealthBar.value <=0)
         Instantiate(ice, iceSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
