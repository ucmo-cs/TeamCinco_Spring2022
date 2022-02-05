using UnityEngine;

namespace MonoBehaviors
{
    public class IsoDiamondMovement : MonoBehaviour
    {
        private Rigidbody2D _player;
        private const float WalkingSpinSpeed = 8000;
        private const float WalkingSpeed = 15;

        private void Start()
        {
            _player = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (_player.angularVelocity < 800)
                {
                    _player.angularVelocity += WalkingSpinSpeed * Time.fixedDeltaTime;
                }

                if (!(_player.velocity.x > -5)) return;
                var velocity = _player.velocity; // cache velocity
                velocity = new Vector2(velocity.x - (WalkingSpeed * Time.fixedDeltaTime), velocity.y);
                _player.velocity = velocity;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (_player.angularVelocity > -800)
                {
                    _player.angularVelocity -= WalkingSpinSpeed * Time.fixedDeltaTime;
                }

                if (!(_player.velocity.x < 5)) return;
                var velocity = _player.velocity; // cache velocity
                velocity = new Vector2(velocity.x + (WalkingSpeed * Time.fixedDeltaTime), velocity.y);
                _player.velocity = velocity;
            }
        }
    }
}