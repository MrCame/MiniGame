using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishController : MonoBehaviour
{
    public float damage;
    private EnemyHealth EH;
    public Rigidbody2D ice;
    public Transform iceSpawn;
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
            prb.AddForce(new Vector2(-3 * prb.velocity.x, 0), ForceMode2D.Impulse);
            PlayerHealth ph = collision.gameObject.GetComponentInParent<PlayerHealth>();
            ph.takeDamage(damage);
        }
    }
    public void MonsterIce()
    {
        EnemyHealth EM = gameObject.GetComponent<EnemyHealth>();
        Rigidbody2D ice = gameObject.GetComponent<Rigidbody2D>();
        if (EM.enemyHealthBar.value <= 0)
            Instantiate(ice, iceSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
