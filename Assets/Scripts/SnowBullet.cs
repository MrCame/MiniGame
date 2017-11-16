using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBullet : MonoBehaviour {

    public float speed = 20f;
	// Use this for initialization

	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
