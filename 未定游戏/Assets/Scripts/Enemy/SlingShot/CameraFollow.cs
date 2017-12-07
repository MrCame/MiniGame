using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public bool isFollow;
    public Transform birdToFollow;

    public const float minCameraX = 0;
    public const float maxCameraX = 13;

    [HideInInspector]
    public Vector3 startPostion;

	// Use this for initialization
	void Start () {
        startPostion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollow)
        {
            if (birdToFollow != null)
            {
                var birdPosition = birdToFollow.transform.position;
                float x = Mathf.Clamp(birdPosition.x, minCameraX, maxCameraX);
                transform.position = new Vector3(x, startPostion.y, startPostion.z);
            } else
                isFollow = false;
        }
	}
}
