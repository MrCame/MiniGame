using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        return;
	}
	
	// Update is called once per frame
	void Update () {
        return;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Save!");
            PlayerPrefs.SetFloat("Savex", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("Savey", gameObject.transform.position.y);
        }
    }
}
