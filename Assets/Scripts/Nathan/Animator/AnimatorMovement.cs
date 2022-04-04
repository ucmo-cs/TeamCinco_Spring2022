using UnityEngine;

public class AnimatorMovement : MonoBehaviour
{
    public GameObject playerGhost;

    const float walkingSpinSpeed = 8000;
    const float walkingSpeed = 15;

    Animator animator;
    Rigidbody2D playerRigidBody;
    Rigidbody2D playerGhostRigidBody;
    Vector2 grabPoint;
    Vector2 grabPointOffset;
    bool grabFlag;
    static readonly int grabbed = Animator.StringToHash("Grabbed");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerGhostRigidBody = playerGhost.GetComponent<Rigidbody2D>();
        
        playerGhost.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Capture input on a per-frame basis.
        if (Input.GetMouseButtonUp(0))
        {
            // Disable grab
            animator.SetBool(grabbed, false);
            grabFlag = true;
        }

        if (Input.GetMouseButton(0) && !animator.GetBool(grabbed)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            if (Vector2.Distance(playerRigidBody.position, mousePosition) < .5) {  // Grab player if mouse is within a certain distance of player.
                // Activate grab
                animator.SetBool(grabbed, true);
                grabFlag = true;
            }
        }
    }

    // FixedUpdate is called once per physics step
    private void FixedUpdate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if (grabFlag) // One time flag for when grab state changes.
        {
            grabFlag = false; // Reset flag.

            if (animator.GetBool(grabbed)) // MOUSE BUTTON DOWN EVENT
            {
                // Save current grab position
                grabPoint = playerRigidBody.position;
                grabPointOffset = (mousePosition - grabPoint) / 2;
                grabPoint.y += .5f; // This makes the player hover in the air a little bit

                // Set up player ghost
                playerGhost.gameObject.SetActive(true);
                playerGhostRigidBody.position = playerRigidBody.position;
                playerGhostRigidBody.rotation = playerRigidBody.rotation;
            }
            else // MOUSE BUTTON UP EVENT
            {
                // Apply velocity, capped at max value(mv).
                var v = playerRigidBody.velocity + playerGhostRigidBody.velocity / 3;
                const float mv = 20;
                v.x = v.x > mv ? mv : v.x;
                v.x = v.x < -mv ? -mv : v.x;
                v.y = v.y > mv ? mv : v.y;
                v.y = v.y < -mv ? -mv : v.y;
                playerRigidBody.velocity = v;

                // Hide player ghost (and reset position.)
                playerGhost.gameObject.SetActive(false);
                playerGhost.gameObject.transform.position = playerRigidBody.position;
            }
        }

        if (animator.GetBool(grabbed)) // Behavior while grabbed
        {
            var currentPosition = playerGhostRigidBody.position;
            var targetPosition = mousePosition - grabPointOffset;

            // Set velocity based on the change in position.
            playerGhostRigidBody.velocity = (targetPosition - currentPosition) * 10;

            // Set angular velocity based on lateral movement.
            playerGhostRigidBody.angularVelocity -=
                playerGhostRigidBody.velocity.x;

            // Constantly move player toward grab point and ghost rotation
            playerRigidBody.angularVelocity = playerRigidBody.angularVelocity * .9f +
                                               (playerGhostRigidBody.rotation - playerRigidBody.rotation);
            playerRigidBody.velocity = playerRigidBody.velocity * .9f + (grabPoint - playerRigidBody.position);
        }
        else // Behavior while not grabbed
        {
            if (Input.GetKey(KeyCode.A)) // LEFT
            {
                goLeft();
            }
            else if (Input.GetKey(KeyCode.D)) // RIGHT
            {
                goRight();
            }
        }
    }

    public void goLeft() {
        if (playerRigidBody.angularVelocity < 800)
        {
            playerRigidBody.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
        }
        if(playerRigidBody.velocity.x > -5)
        {
            var velocity = playerRigidBody.velocity; // cache velocity
            velocity = new Vector2(velocity.x - (walkingSpeed * Time.fixedDeltaTime), velocity.y);
            playerRigidBody.velocity = velocity;
        }
    }

    public void goRight() {
        if (playerRigidBody.angularVelocity > -800)
        {
            playerRigidBody.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
        }
        if (playerRigidBody.velocity.x < 5)
        {
            var velocity = playerRigidBody.velocity; // cache velocity
            velocity = new Vector2(velocity.x + (walkingSpeed * Time.fixedDeltaTime), velocity.y);
            playerRigidBody.velocity = velocity;
        }
    }
}