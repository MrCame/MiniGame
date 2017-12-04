using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float minSize;
    public float maxSize;
    private GameObject player;
    private PlayerController pc;
    private Camera cam;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(player.transform.position.x, transform.localPosition.y, -8);
        if (player.transform.position.y + cam.orthographicSize >= 16.25f || player.transform.position.y - cam.orthographicSize <= -16.25)
            return;
        if (pc.onGround == true && pc.focus == true && cam.orthographicSize > minSize)
        {
            cam.orthographicSize = cam.orthographicSize - 0.05f;
        }
        if (pc.onGround == true && pc.focus == false && cam.orthographicSize < maxSize)
        {
            cam.orthographicSize = cam.orthographicSize + 0.05f;
        }
        if (player == null) return;
        transform.localPosition = new Vector3(player.transform.position.x, player.transform.position.y, -8);
    }
}
