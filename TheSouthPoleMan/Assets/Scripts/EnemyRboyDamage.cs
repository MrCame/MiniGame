using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRboyDamage : MonoBehaviour {

    public float Damage;
    private PlayerController pc;
    private PlayerHealth ph;
    private EnemyRboyController erc;
    private bool inside = false;
	// Use this for initialization
	void Start () {
        erc = GetComponent<EnemyRboyController>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (GetComponentInChildren<EnemyHealth>() == null)
        {
            Destroy(gameObject);
        }
        if (inside == false)
            return;
        else if ((pc.faceright == false && erc.faceRight == 1) || (pc.faceright==true && erc.faceRight == -1)) 
            ph.takeDamage(Damage);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pc = other.gameObject.GetComponent<PlayerController>();
            ph = other.gameObject.GetComponent<PlayerHealth>();
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = false;
        }
    }

}
    
