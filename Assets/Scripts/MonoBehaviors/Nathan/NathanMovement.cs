using UnityEngine;

public class NathanMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    // FixedUpdate is called once per physics step
    private void FixedUpdate()
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