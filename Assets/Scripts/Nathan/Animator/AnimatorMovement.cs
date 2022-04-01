using UnityEngine;

public class AnimatorMovement : MonoBehaviour
{
    public GameObject playerGhost;

    private Animator animator;
    private Rigidbody2D playerRigidBody;
    private Vector2 grabPoint;
    private Vector2 grabPointOffset;
    private bool grabbedChanged;
    //private bool grabbed;    <--- this is now be an animator controlled variable instead.

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        playerRigidBody = GetComponent<Rigidbody2D>();
        playerGhost.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // Capture input on a per-frame basis.
        if (Input.GetMouseButtonUp(0))
        {
            // Disable grab
            animator.SetBool("Grabbed", false);
            grabbedChanged = true;
        }

        if (!Input.GetMouseButton(0) || animator.GetBool("Grabbed")) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if (!(Vector2.Distance(playerRigidBody.position, mousePosition) < .5)) return;
        // Activate grab
        animator.SetBool("Grabbed", true);
        grabbedChanged = true;
    }

    // FixedUpdate is called once per physics step
    private void FixedUpdate()
    {
        if (grabbedChanged) // One time flag for when grab state changes.
        {
            grabbedChanged = false; // Reset flag.

            if (animator.GetBool("Grabbed")) // MOUSE BUTTON DOWN EVENT
            {
                // Save current grab position
                grabPoint = playerRigidBody.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                grabPointOffset = (mousePosition - grabPoint) / 2;
                grabPoint.y += .5f; // This makes the player hover in the air a little bit

                // Set up player ghost
                playerGhost.gameObject.SetActive(true);
                playerGhost.GetComponent<Rigidbody2D>().position = playerRigidBody.position;
                playerGhost.GetComponent<Rigidbody2D>().rotation = playerRigidBody.rotation;
            }
            else // MOUSE BUTTON UP EVENT
            {
                // Apply velocity, capped at max value(mv).
                var v = playerRigidBody.velocity + playerGhost.GetComponent<Rigidbody2D>().velocity / 3;
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

        if (animator.GetBool("Grabbed")) // Behavior while grabbed
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            var currentPosition = playerGhost.GetComponent<Rigidbody2D>().position;
            var targetPosition = mousePosition - grabPointOffset;

            // Set velocity based on the change in position.
            playerGhost.GetComponent<Rigidbody2D>().velocity = (targetPosition - currentPosition) * 10;

            // Set angular velocity based on lateral movement.
            playerGhost.GetComponent<Rigidbody2D>().angularVelocity -=
                playerGhost.GetComponent<Rigidbody2D>().velocity.x;

            // Constantly move player toward grab point and ghost rotation
            playerRigidBody.angularVelocity = playerRigidBody.angularVelocity * .9f +
                                               (playerGhost.GetComponent<Rigidbody2D>().rotation -
                                                playerRigidBody.rotation);
            playerRigidBody.velocity = playerRigidBody.velocity * .9f + (grabPoint - playerRigidBody.position);
        }
        else // Behavior while not grabbed
        {
            const float walkingSpinSpeed = 8000;
            const float walkingSpeed = 15;

            if (Input.GetKey(KeyCode.A) && playerRigidBody.angularVelocity < 800) // LEFT
            {
                playerRigidBody.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.D) && playerRigidBody.angularVelocity > -800) // RIGHT
            {
                playerRigidBody.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
            }

            if (Input.GetKey(KeyCode.A) && playerRigidBody.velocity.x > -5) // LEFT
            {
                var velocity = playerRigidBody.velocity; // cache velocity
                velocity = new Vector2(velocity.x - (walkingSpeed * Time.fixedDeltaTime), velocity.y);
                playerRigidBody.velocity = velocity;
            }
            else if (Input.GetKey(KeyCode.D) && playerRigidBody.velocity.x < 5) // RIGHT
            {
                var velocity = playerRigidBody.velocity; // cache velocity
                velocity = new Vector2(velocity.x + (walkingSpeed * Time.fixedDeltaTime), velocity.y);
                playerRigidBody.velocity = velocity;
            }
        }
    }
}