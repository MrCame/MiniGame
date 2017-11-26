﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D shot;
    public Transform shotSpawn;
    public float speed = 10f;               // The speed the rocket will fire at.

    public float fireRate = 0.1f; //the frequency of shoot 
    private float nextFire = 0f;

    private PlayerController playerCtrl;       // Reference to the PlayerControl script.
    private Animator anim;                  // Reference to the Animator component.


    void Awake()
    {
        // Setting up the references.
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerController>();
    }


    void Update ()
    {
        // If the fire button is pressed...
        if (Input.GetKey (KeyCode.A) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            // ... set the animator Shoot trigger parameter and play the audioclip.
            anim.SetTrigger("Shoot");
            anim.SetTrigger("StandShoot");

            // If the player is facing right...
            if(playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
