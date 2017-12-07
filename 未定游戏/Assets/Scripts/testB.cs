using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testB : MonoBehaviour {
    public Transform[] pos;
    public  int index = 0;
    public float speed = 5;
    void Update()
    {
        transform.Translate((pos[index].position - transform.position).normalized * Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, pos[index].position) <1f) {
            index++;
        }

        if (index > 1) {
            index = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        other.gameObject.transform.parent = transform;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.transform.parent = null;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame

}
