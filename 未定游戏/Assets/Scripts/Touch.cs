using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    private PlayerController player1;
    private Shoot player2;

    void Start()
    {
        player1 = FindObjectOfType<PlayerController>();
        player2 = FindObjectOfType<Shoot>();
    }

    public void Jump()
    {
        player1.TouchJump = true;
    }
    public void Attack()
    {
        player2.TouchAttack = true;
    }
    public void LeftArrow()
    {
        player1.TouchGet = true;
        player1.h = -1;
    }
    public void RightArrow()
    {
        player1.TouchGet = true;
        player1.h = 1;
    }
    public void ReleaseLeftArrow()
    {
        player1.TouchGet = false;
        player1.h = 0;
    }
    public void ReleaseRightArrow()
    {
        player1.TouchGet = false;
        player1.h = 0;
    }
    
}
