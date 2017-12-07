using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

// 自动添加rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour {

    public BirdState State
    {
        get;
        private set;
    }

	// Use this for initialization
	void Start () {
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().sortingLayerName = "foreground";

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusNormal;

        State = BirdState.BeforeThrown;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (State == BirdState.Thrown && GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= Constants.MinVelocity)
        {
            StartCoroutine(DestroyAfter(2));
        }
	}

    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public void OnThrow()
    {
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<Rigidbody2D>().isKinematic = false;

        State = BirdState.Thrown;
    }
}
