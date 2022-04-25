using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{

    public Transform limbSolverTarget;
    public float moveDistance;
    public LayerMask groundLayer;
    Vector2 start;
    Vector2 target;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start() {
        start = limbSolverTarget.position;
        target = limbSolverTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();

        if(Vector2.Distance(limbSolverTarget.position,transform.position) > moveDistance){
            start = limbSolverTarget.position;
            target = transform.position;
        }
    }

    void FixedUpdate() {
        limbSolverTarget.position = (Vector2)limbSolverTarget.position + (target-(Vector2)limbSolverTarget.position)/2.5f;
        // Gets the relative distance from the current position of the leg and the nearest start/stop point. (Value will be highest during the middle of a step.)
        var y = ((target.x-start.x)/2f)-Mathf.Abs((start.x+((target.x-start.x)/2f))-limbSolverTarget.position.x);
        limbSolverTarget.position = new Vector2(limbSolverTarget.position.x,limbSolverTarget.position.y+y);
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
