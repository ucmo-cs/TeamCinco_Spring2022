using System;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public const float walkingSpinSpeed = 8000;
    public float walkingSpeed = 15;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (player.angularVelocity < 800)
            {
                player.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
            }

            if (!(player.velocity.x > -5)) return;
            var velocity = player.velocity; // cache velocity
            velocity = new Vector2(velocity.x - (walkingSpeed * Time.fixedDeltaTime), velocity.y);
            player.velocity = velocity;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (player.angularVelocity > -800)
            {
                player.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
            }

            if (!(player.velocity.x < 5)) return;
            var velocity = player.velocity; // cache velocity
            velocity = new Vector2(velocity.x + (walkingSpeed * Time.fixedDeltaTime), velocity.y);
            player.velocity = velocity;
        }
    }
}