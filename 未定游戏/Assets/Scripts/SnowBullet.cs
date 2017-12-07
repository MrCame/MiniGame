using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBullet : MonoBehaviour {

	// Use this for initialization
    public float alivetime = 0.7f;
    public GameObject explosion;
	void Start () {
        Destroy(gameObject, alivetime);
        StartCoroutine(Count()); 
	}
	
    IEnumerator Count()  
    {  
        float expnew = 0.9f * alivetime;
        yield return new WaitForSeconds(expnew); 
        Instantiate(explosion, transform.position, transform.rotation); 
    } 
	// Update is called once per frame
	
}
