using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ThrowerController : MonoBehaviour {

    [HideInInspector]
    public Vector3 middleVector;

    public LineRenderer leftLineRenderer;
    public LineRenderer rightLineRenderer;

    public Transform birdPostion;
    public Transform leftOrigin, rightOrigin;

    public LineRenderer trajectoryLineRenderer;
    public float throwSpeed;

    public GameObject birdToThrow;

    [HideInInspector]
    public SlingShotState slingShotState;

    public float BirdDistance = 2;

    // 发射的时刻
    [HideInInspector]
    public float TimeSinceThrown;

    // Use this for initialization
    void Start () {
        leftLineRenderer.sortingLayerName = "foreground";
        rightLineRenderer.sortingLayerName = "foreground";

        leftLineRenderer.sortingOrder = 0;
        rightLineRenderer.sortingOrder = 0;

        trajectoryLineRenderer.sortingLayerName = "foreground";

        leftLineRenderer.SetPosition(0, leftOrigin.position);
        rightLineRenderer.SetPosition(0, rightOrigin.position);

        middleVector = new Vector3((leftOrigin.position.x + rightOrigin.position.x) / 2,
                                   (rightOrigin.position.y + rightOrigin.position.y) / 2,
                                   0);

    }

    // Update is called once per frame
    void Update()
    {
        switch(slingShotState)
        {
            case SlingShotState.Idle:
                InitializeBird();

                SetSlingshotLineRendereActive(true);
                SetTrajectoryLineRendererActive(true);

                DisplayLineRenderer();
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (birdToThrow.GetComponent<CircleCollider2D>() == Physics2D.OverlapPoint(location))
                    {
                        slingShotState = SlingShotState.UserPulling;
                    }
                }
                break;

            case SlingShotState.UserPulling:
                DisplayLineRenderer();
                if (Input.GetMouseButton(0))
                {
                    Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    location.z = 0;
                    if (Vector3.Distance(location, middleVector) > BirdDistance)
                    {
                        var maxPosition = (location - middleVector).normalized * BirdDistance + middleVector;
                        birdToThrow.transform.position = maxPosition;
                    }
                    else
                    {
                        birdToThrow.transform.position = location;
                    }
                    float distance = Vector3.Distance(middleVector, birdPostion.position);
                    DisplayTrajectoryLineRenderer(distance);
                }
                else
                {
                    SetTrajectoryLineRendererActive(false);

                    TimeSinceThrown = Time.time;

                    float distance = Vector3.Distance(middleVector, birdToThrow.transform.position);
                    if (distance > 1)
                    {
                        SetSlingshotLineRendereActive(false);
                        slingShotState = SlingShotState.BirdFlying;
                        ThrowBird(distance);
                    }
                    else
                    {
                        birdToThrow.transform.positionTo(distance / 10, birdPostion.transform.position)
                            .setOnCompleteHandler((x) =>
                            {
                                x.complete();
                                x.destroy();
                                InitializeBird();
                            });
                    }
                }
                break;
        }
    }

    void SetTrajectoryLineRendererActive(bool active)
    {
        //trajectoryLineRenderer.enabled = active;
        trajectoryLineRenderer.enabled = false;
    }

    void SetSlingshotLineRendereActive(bool active)
    {
        leftLineRenderer.enabled = active;
        rightLineRenderer.enabled = active;
    }

    void ThrowBird(float distance)
    {
        Vector3 velcocity = middleVector - birdToThrow.transform.position;

        birdToThrow.GetComponent<Bird>().OnThrow();

        birdToThrow.GetComponent<Rigidbody2D>().velocity = new Vector2(velcocity.x, velcocity.y) * throwSpeed * distance;
    }

    private void DisplayLineRenderer()
    {
        //leftLineRenderer.SetPosition(1, birdPostion.position);
        //rightLineRenderer.SetPosition(1, birdPostion.position);

        leftLineRenderer.SetPosition(1, birdToThrow.transform.position);
        rightLineRenderer.SetPosition(1, birdToThrow.transform.position);
    }

    private void DisplayTrajectoryLineRenderer(float distance)
    {
        // x axis : space x = initSpaceX + velocityX * time;
        // y axis : space Y = initSpaceY + velocityY * time + 0.5 * accelerationY * time ^ 2;
        //Vector2 v2 = middleVector - birdPostion.position;
        Vector2 v2 = middleVector - birdToThrow.transform.position;
        int segmentCount = 15;

        Vector2[] segments = new Vector2[segmentCount];

        //segments[0] = birdPostion.position;
        segments[0] = birdToThrow.transform.position;

        Vector2 segVelocity = new Vector2(v2.x, v2.y) * throwSpeed * distance;

        for (int i = 1; i < segmentCount; i++)
        {
            float time2 = i * Time.fixedDeltaTime * 5;
            segments[i] = segments[0] + segVelocity * time2 + 0.5f * Physics2D.gravity * Mathf.Pow(time2, 2);
        }

        trajectoryLineRenderer.SetVertexCount(segmentCount);
        for (int i = 0; i < segmentCount; i++)
        {
            trajectoryLineRenderer.SetPosition(i, segments[i]);
        }
    }

    void InitializeBird()
    {
        birdToThrow.transform.position = birdPostion.position;
        slingShotState = SlingShotState.Idle;
    }
}
