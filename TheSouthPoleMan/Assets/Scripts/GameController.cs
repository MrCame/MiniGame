using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int health;
    public int face;
    public GameObject character;
    private GameObject player;

	// Use this for initialization
	void Start () {
        health = 100;
        face = 0;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (health == 0)
            Destroy(player);
	}

    public void takedamage(int damage)
    {
        if(health>0)
        health -= damage;
    }
}
