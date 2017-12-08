using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishController : MonoBehaviour
{
    public float pushForce;
    public float damage;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D prb = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.hit = true;
            prb.AddForce(new Vector2(-pushForce * prb.velocity.x, 0), ForceMode2D.Impulse);
            PlayerHealth ph = collision.gameObject.GetComponentInParent<PlayerHealth>();
            ph.takeDamage(damage);
        }
    }
}
