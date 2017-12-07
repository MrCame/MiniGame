using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHit : MonoBehaviour
{

    public float weapondamage;
    public GameObject explosion;
    private ShotSpeed sh;
    private PlayerHealth ph;
    // Use this for initialization
    void Awake()
    {
        sh = GetComponent<ShotSpeed>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(sh.icespeed, 0) ||
            gameObject.GetComponent<Rigidbody2D>().velocity == new Vector2(-sh.icespeed, 0))
            return;
        else Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sh.removeForce();
            ph = other.GetComponent<PlayerHealth>();
            ph.takeDamage(weapondamage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sh.removeForce();
            ph = other.GetComponent<PlayerHealth>();
            ph.takeDamage(weapondamage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
