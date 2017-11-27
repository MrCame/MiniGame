using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabbitDamage : MonoBehaviour {

    public float pushForce;
    public float damage;
    private EnemyRabbitController erc;
    private PlayerController pc;
    private PlayerHealth ph;
	// Use this for initialization
	void Start () {
        erc = GetComponentInParent<EnemyRabbitController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pc = other.gameObject.GetComponent<PlayerController>();
            pc.hit = true;
            pushback(other.transform);
            ph = other.gameObject.GetComponent<PlayerHealth>();
            if (ph.currentHealth <= damage)
                erc.canFlip = true;
            ph.takeDamage(damage);
        }
    }

    void pushback(Transform pushedObject)
    {
        float faceright = erc.faceRight;
        Rigidbody2D rb = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(faceright*pushForce, 0),ForceMode2D.Impulse);
    }
}
