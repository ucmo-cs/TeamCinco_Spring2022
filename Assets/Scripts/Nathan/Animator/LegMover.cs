using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{

    public Transform limbSolverTarget;
    public float moveDistance;
    public LayerMask groundLayer;

    bool moving;
    Vector3 startPos;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Update is called once per frame
    void Update()
    {
        checkGround();

        if(Vector2.Distance(limbSolverTarget.position,transform.position) > moveDistance){
            moving = true;
            //startPos = limbSolverTarget.position;
            limbSolverTarget.position = transform.position;
        }
        // if (moving) {
        //     // Distance moved equals elapsed time times speed..
        //     float distCovered = (Time.time - startTime) * speed;

        //     // Fraction of journey completed equals current distance divided by total distance.
        //     float fractionOfJourney = distCovered / journeyLength;

        //     // Set our position as a fraction of the distance between the markers.
        //     limbSolverTarget.position = Vector3.Lerp(startPos, transform.position, fractionOfJourney);
        // }
    }

    void checkGround() {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector3.down, 5, groundLayer);
        if(hit.collider != null) {
            Vector3 point = hit.point; // gets pos where leg hit something
            point.y += 0.1f;
            transform.position = point;
        }
    }
}
