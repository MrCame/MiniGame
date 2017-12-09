using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowHealth : MonoBehaviour {
    private PlayerHealth PH;
    public float snowHealth = 50;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void onTriggerEnter2D(Collider2D other) {
        Debug.Log("HH");
        if (other.tag == "Player") {
            PH = other.gameObject.GetComponent<PlayerHealth>();
            PH.takeDamage(snowHealth);
            Destroy(gameObject);           
        }
    }

   /* void onCollisionEnter2D(Collision2D other)
    {
        Debug.Log("AA");
        if (other.collider.tag == "Player")
        {
            PH = other.collider.GetComponent<PlayerHealth>();
            PH.takeDamage(snowHealth);
            Destroy(this.gameObject, 2);

        }

    }*/
}
