using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaryController : MonoBehaviour {

    [HideInInspector]
    public bool dead;
    private EnemyHealth eh;
	// Use this for initialization
	void Start () {
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<EnemyHealth>() == null)  //judge if mary is dead
        {
            dead = true;
        }
	}
}
