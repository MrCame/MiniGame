using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animation))]
public class Bridge : MonoBehaviour {

    private Animation animation;

    private bool isPlayed = false;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown(KeyCode.T))
        //{
        //    DoAction();
        //}
	}

    public void DoAction()
    {
        if (!isPlayed)
        {
            animation.Play();
            isPlayed = true;
        }
        
    }

    public void Attack()
    {
        Destroy(gameObject);
    }
}
