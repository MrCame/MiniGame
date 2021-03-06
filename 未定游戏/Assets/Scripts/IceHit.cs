﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceHit : MonoBehaviour {

    public float weapondamage;
    public GameObject explosion;
    private ShotSpeed sh;
    private EnemyHealth eh;
    public GameObject flake;
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
            if (other.GetComponent<EnemyHealth>() != null)
            {
                eh = other.GetComponent<EnemyHealth>();
            }
            else
            {
                eh = other.GetComponentInParent<EnemyHealth>();
            }
            eh.takeDamage(weapondamage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.tag == "Ice")
        {
            Destroy(other.gameObject);
            Instantiate(flake, other.transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
                if (other.GetComponent<EnemyHealth>() != null)
                {
                    eh = other.GetComponent<EnemyHealth>();
                }
                else
                {
                    eh = other.GetComponentInParent<EnemyHealth>();
                }
            eh.takeDamage(weapondamage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
