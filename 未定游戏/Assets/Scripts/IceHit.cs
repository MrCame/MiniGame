using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceHit : MonoBehaviour {

    public float weapondamage;
    public GameObject explosion;
    private ShotSpeed sh;
    private EnemyHealth eh;
	// Use this for initialization
	void Awake () {
        sh = GetComponent<ShotSpeed>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            eh = other.GetComponent<EnemyHealth>();
            eh.takeDamage(weapondamage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            eh = other.GetComponent<EnemyHealth>();
            eh.takeDamage(weapondamage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
