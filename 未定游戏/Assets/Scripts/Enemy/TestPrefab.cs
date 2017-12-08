using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefab : MonoBehaviour {
    private GameObject hp_bar;
    private GameObject mary;
	// Use this for initialization
	void Start () {
        changePrefab();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changePrefab() {
        GameObject hp_bar = (GameObject)Instantiate(Resources.Load("test"));
        GameObject mary = GameObject.Find("Enemy_mary");
        hp_bar.transform.parent = mary.transform;
    }
}
