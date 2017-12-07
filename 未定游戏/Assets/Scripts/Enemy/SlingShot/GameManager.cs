using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GameManager : MonoBehaviour {

    private List<GameObject> Birds;

    public static GameState currentGameState = GameState.Start;

    public ThrowerController slingshot;

    int currentBirdIndex;

	// Use this for initialization
	void Start () {

        slingshot.enabled = false;

        Birds = new List<GameObject>(GameObject.FindGameObjectsWithTag("bird"));

        currentGameState = GameState.Start;
    }
	
	// Update is called once per frame
	void Update () {
		switch(currentGameState)
        {
            case GameState.Start:
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("before");
                    AnimateBirdToSlingshot();
                    Debug.Log("after");
                }
                break;
            case GameState.Playing:
                if (slingshot.slingShotState == SlingShotState.BirdFlying &&
                    Time.time - slingshot.TimeSinceThrown > 2f
                    //(BricksBirdPigsStoppedMove() || Time.time - slingshot.TimeSinceThrown > 5f)
                    )
                {
                    // 相机回归
                    slingshot.enabled = false;

                    //Debug.Log("return");

                    slingshot.slingShotState = SlingShotState.Idle;
                    currentBirdIndex++;
                    AnimateBirdToSlingshot();

                    currentGameState = GameState.BirdMovingToSlingshot;
                }
                break;
        }
	}

    void AnimateBirdToSlingshot()
    {
        if (currentBirdIndex < Birds.Count)
        {
            Birds[currentBirdIndex]
                .transform
                .positionTo(
                    Vector2.Distance(
                        Birds[currentBirdIndex].transform.position / 10,
                        slingshot.birdPostion.transform.position / 10),
                    slingshot.birdPostion.transform.position)
                .setOnCompleteHandler((x) =>
                {
                    x.complete();
                    x.destroy();
                    currentGameState = GameState.Playing;
                    slingshot.birdToThrow = Birds[currentBirdIndex];
                    slingshot.enabled = true;
                });
        }

    }

    bool BricksBirdPigsStoppedMove()
    {
        foreach(var item in Birds)
        {
            if (item != null && item.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > Constants.MinVelocity)
            {
                return false;
            }
        }
        return true;
    }

    void AnimateCameraToStartPostion()
    {

    }
}
