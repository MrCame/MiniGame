using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeed : MonoBehaviour {

    public float icespeed;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z <= 0)
        {
            rb.AddForce(new Vector2(1, 0) * icespeed, ForceMode2D.Impulse);
        }
        else if(transform.localRotation.z>0)
        {
            rb.AddForce(new Vector2(-1, 0) * icespeed, ForceMode2D.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void removeForce()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
