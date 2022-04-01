using UnityEngine;

public class NathanMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    const float walkingSpinSpeed = 8000;
    const float walkingSpeed = 15;
    float slowdown;
    public bool disabled;

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        slowdown = playerRigidBody.gravityScale;
        disabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    // FixedUpdate is called once per physics step
    private void FixedUpdate()
    {
        if(!disabled) {
            if(slowdown < .1) slowdown = .1f;
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
        if (playerRigidBody.angularVelocity < 800) // LEFT
        {
            playerRigidBody.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
        }
        if(playerRigidBody.velocity.x > -5)
        {
            var velocity = playerRigidBody.velocity; // cache velocity
            velocity = new Vector2(velocity.x - (walkingSpeed*slowdown * Time.fixedDeltaTime), velocity.y);
            playerRigidBody.velocity = velocity;
        }
    }

    public void goRight() {
        if (playerRigidBody.angularVelocity > -800) // RIGHT
        {
            playerRigidBody.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
        }
        if (playerRigidBody.velocity.x < 5) // RIGHT
        {
            var velocity = playerRigidBody.velocity; // cache velocity
            velocity = new Vector2(velocity.x + (walkingSpeed*slowdown * Time.fixedDeltaTime), velocity.y);
            playerRigidBody.velocity = velocity;
        }
    }
}