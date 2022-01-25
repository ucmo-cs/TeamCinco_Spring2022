using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerGhost;
    
    private Rigidbody2D playerRigidBody;
    private Vector2 grabPoint = new Vector2();
    private Vector2 grabPointOffset = new Vector2();
    private bool grabbed = false;
    private bool grabbedChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        playerGhost.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // Capture input on a per-frame basis.
        if (Input.GetMouseButtonUp(0)) {
            // Disable grab
            grabbed = false;
            grabbedChanged = true;
        }
        if (Input.GetMouseButton(0) && !grabbed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(playerRigidBody.position, mousePosition) < .5) {
                // Activate grab
                grabbed = true;
                grabbedChanged = true;
            }
        }
    }

    // FixedUpdate is called once per physics step
    private void FixedUpdate() {
        // One time flag for when grab state changes.
        if(grabbedChanged) {
            grabbedChanged = false; // Reset flag.

            // MOUSE BUTTON DOWN EVENT
            if (grabbed) {
                // Save current grab postion
                grabPoint = playerRigidBody.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                grabPointOffset = (mousePosition - grabPoint)/2;
                grabPoint.y += .5f; // This makes the player hover in the air a little bit

                // Set up player ghost
                playerGhost.gameObject.SetActive(true);
                playerGhost.GetComponent<Rigidbody2D>().position = playerRigidBody.position;
                playerGhost.GetComponent<Rigidbody2D>().rotation= playerRigidBody.rotation;
            }
            // MOUSE BUTTON UP EVENT
            else {
                // Apply velocity, capped at max value(mv).
                Vector2 v = playerRigidBody.velocity + playerGhost.GetComponent<Rigidbody2D>().velocity/3;
                float mv = 20;
                v.x = v.x>mv?mv:v.x;
                v.x = v.x<-mv?-mv:v.x;
                v.y = v.y>mv?mv:v.y;
                v.y = v.y<-mv?-mv:v.y;
                playerRigidBody.velocity = v;

                // Hide player ghost
                playerGhost.gameObject.SetActive(false);
            }
        }

        // Behavior while grabbed
        if (grabbed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 currentPosition = playerGhost.GetComponent<Rigidbody2D>().position;
            Vector2 targetPosition = mousePosition - grabPointOffset;

            // Set velocity baised on the change in position.
            playerGhost.GetComponent<Rigidbody2D>().velocity = (targetPosition-currentPosition)*10;

            // Set angular velocity baised on lateral movemet.
            playerGhost.GetComponent<Rigidbody2D>().angularVelocity += -playerGhost.GetComponent<Rigidbody2D>().velocity.x;

            // Constantly move player toward grab point and ghost rotation
            playerRigidBody.angularVelocity += (playerGhost.GetComponent<Rigidbody2D>().rotation - playerRigidBody.rotation);
            playerRigidBody.velocity = playerRigidBody.velocity*.9f + (grabPoint - playerRigidBody.position);
        } 
        // Behavior while not grabbed
        else {
            float walkingSpinSpeed = 10000;
            float walkingSpeed = 5;
            if (Mathf.Abs(playerRigidBody.angularVelocity) < 500){
                if (Input.GetKey(KeyCode.A)) { // LEFT
                    playerRigidBody.angularVelocity = playerRigidBody.angularVelocity+(walkingSpinSpeed*Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.D)) { // RIGHT
                    playerRigidBody.angularVelocity = playerRigidBody.angularVelocity-(walkingSpinSpeed*Time.deltaTime);
                }
            }
            if (Mathf.Abs(playerRigidBody.velocity.x) < 5){
                if (Input.GetKey(KeyCode.A)) { // LEFT
                    playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x-(walkingSpeed*Time.deltaTime), playerRigidBody.velocity.y);
                }
                else if (Input.GetKey(KeyCode.D)) { // RIGHT
                    playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x+(walkingSpeed*Time.deltaTime), playerRigidBody.velocity.y);
                }
            }
        }
    }

    public bool isGrabbed() {
        return grabbed;
    }
}
