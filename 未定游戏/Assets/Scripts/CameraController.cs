using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float minSize; //default should be 8
    public float maxSize; //default should be 8
    private GameObject player;
    private PlayerController pc;
    private Camera cam;
    private float camx, camy; //current x,y value of target
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        cam = GetComponent<Camera>();
        transform.localPosition = new Vector3(-21.18f, -2.14f, -8);  //target for initialization
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y + cam.orthographicSize >= 16.25f || player.transform.position.y - cam.orthographicSize <= -16.25)
        {
            camy = transform.localPosition.y;
        }
        else camy = player.transform.position.y;
        if (player.transform.position.x <= -21.18f)
        {
            camx = transform.localPosition.x;
        }
        else camx = player.transform.position.x;
        transform.localPosition = new Vector3(camx, camy, -8);

        //shift camera size if needed
        if (pc.onGround == true && pc.focus == true && cam.orthographicSize > minSize)
        {
            cam.orthographicSize = cam.orthographicSize - 0.05f;
        }
        if (pc.onGround == true && pc.focus == false && cam.orthographicSize < maxSize)
        {
            cam.orthographicSize = cam.orthographicSize + 0.05f;
        }
        if (player == null) return;
    }
}
