using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMothController : MonoBehaviour {

    public GameObject waveShot;
    public Transform shotSpawn;
    private bool shootRight;
    private float fireRate = 3.0f;
    private float nextFire = 0f;
    public Rigidbody2D ice;
    public Transform iceSpawn;

    // Use this for initialization
    void Start () {
        shootRight = true;
    }
	
	// Update is called once per frame
	void Update () {
        fireWave();
        if (GetComponentInChildren<EnemyHealth>() == null)
            Destroy(gameObject);
    }

    void fireWave()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (!shootRight)
            {
                Instantiate(waveShot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0f)));
            }
            else if (shootRight)
            {
                Instantiate(waveShot, shotSpawn.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x > transform.position.x)
                shootRight = false;
            else shootRight = true;
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x > transform.position.x)
                shootRight = false;
            else shootRight = true;
        }
    }

    public void MonsterIce()
    {
        Instantiate(ice, iceSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
