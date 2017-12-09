using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaryController : MonoBehaviour {

    [HideInInspector]
    public bool dead;
    private EnemyHealth eh;
    private bool icemade;
    public Rigidbody2D ice;
    public Transform iceSpawn;
    // Use this for initialization
    void Start () {
        dead = false;
        icemade = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<EnemyHealth>() == null)  //judge if mary is dead
        {
            dead = true;
            if (icemade == false) {
                Instantiate(ice, iceSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                icemade = true;
            }           
        }
	}
}
