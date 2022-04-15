using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMover : MonoBehaviour
{

    public Transform limbSolverTarget;
    public float moveDistance;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkGround();

        if(Vector2.Distance(limbSolverTarget.position,transform.position) > moveDistance){
            limbSolverTarget.position = transform.position;
        }
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
