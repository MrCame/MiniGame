using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Jump()
    {
        player.jump = true;
    }
    public void LeftArrow()
    {
        player.moveright = false;
        player.moveleft = true;
    }
    public void RightArrow()
    {
        player.moveright = true;
        player.moveleft = false;
    }
    public void ReleaseLeftArrow()
    {
        player.moveleft = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveright = false;

    }
    
}
