using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexPlayerMovement : MonoBehaviour
{
    public GameObject playerGhost;

    public AlexCooldownTimer timer;

    private Rigidbody2D _playerRigidBody;
    private Vector2 _grabPoint;
    private Vector2 _grabPointOffset;
    private Vector3 oldPos;
    private bool _grabbed;
    private bool _grabbedChanged;
    private float totalDistance = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        playerGhost.gameObject.SetActive(false);
        oldPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        Vector3 distanceVector = transform.position - oldPos;
        if (!timer._doneWaiting)
        {
            timer._doneWaiting = timer.UpdateTimer(distanceVector.magnitude);
            return;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Capture input on a per-frame basis.
        if (Input.GetMouseButtonUp(0))
        {
            // Disable grab
            _grabbed = false;
            _grabbedChanged = true;
        }

        if (!timer._doneWaiting) {
            return;
        }

        if (!Input.GetMouseButton(0) || _grabbed) return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!(Vector2.Distance(_playerRigidBody.position, mousePosition) < .5)) return;
        // Activate grab
        _grabbed = true;
        _grabbedChanged = true;
    }

    // FixedUpdate is called once per physics step
    private void FixedUpdate()
    {
        if (_grabbedChanged) // One time flag for when grab state changes.
        {
            _grabbedChanged = false; // Reset flag.

            if (_grabbed && timer._doneWaiting) // MOUSE BUTTON DOWN EVENT
            {
                // Save current grab position
                _grabPoint = _playerRigidBody.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _grabPointOffset = (mousePosition - _grabPoint) / 2;
                _grabPoint.y += .5f; // This makes the player hover in the air a little bit

                // Set up player ghost
                playerGhost.gameObject.SetActive(true);
                playerGhost.GetComponent<Rigidbody2D>().position = _playerRigidBody.position;
                playerGhost.GetComponent<Rigidbody2D>().rotation = _playerRigidBody.rotation;
            }
            else // MOUSE BUTTON UP EVENT
            {
                // Apply velocity, capped at max value(mv).
                var v = _playerRigidBody.velocity + playerGhost.GetComponent<Rigidbody2D>().velocity / 3;
                const float mv = 20;
                v.x = v.x > mv ? mv : v.x;
                v.x = v.x < -mv ? -mv : v.x;
                v.y = v.y > mv ? mv : v.y;
                v.y = v.y < -mv ? -mv : v.y;
                _playerRigidBody.velocity = v;

                // Hide player ghost
                playerGhost.gameObject.SetActive(false);
                timer._doneWaiting = false;
            }
        }

        if (_grabbed && timer._doneWaiting) // Behavior while grabbed
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var currentPosition = playerGhost.GetComponent<Rigidbody2D>().position;
            var targetPosition = mousePosition - _grabPointOffset;

            // Set velocity based on the change in position.
            playerGhost.GetComponent<Rigidbody2D>().velocity = (targetPosition - currentPosition) * 10;

            // Set angular velocity based on lateral movement.
            playerGhost.GetComponent<Rigidbody2D>().angularVelocity -=
                playerGhost.GetComponent<Rigidbody2D>().velocity.x;

            // Constantly move player toward grab point and ghost rotation
            _playerRigidBody.angularVelocity = _playerRigidBody.angularVelocity * .9f +
                                               (playerGhost.GetComponent<Rigidbody2D>().rotation -
                                                _playerRigidBody.rotation);
            _playerRigidBody.velocity = _playerRigidBody.velocity * .9f + (_grabPoint - _playerRigidBody.position);
        }
        else // Behavior while not grabbed
        {
            const float walkingSpinSpeed = 8000;
            const float walkingSpeed = 15;

            if (Input.GetKey(KeyCode.A) && _playerRigidBody.angularVelocity < 800) // LEFT
            {
                _playerRigidBody.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.D) && _playerRigidBody.angularVelocity > -800) // RIGHT
            {
                _playerRigidBody.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
            }

            if (Input.GetKey(KeyCode.A) && _playerRigidBody.velocity.x > -5) // LEFT
            {
                var velocity = _playerRigidBody.velocity; // cache velocity
                velocity = new Vector2(velocity.x - (walkingSpeed * Time.fixedDeltaTime), velocity.y);
                _playerRigidBody.velocity = velocity;
            }
            else if (Input.GetKey(KeyCode.D) && _playerRigidBody.velocity.x < 5) // RIGHT
            {
                var velocity = _playerRigidBody.velocity; // cache velocity
                velocity = new Vector2(velocity.x + (walkingSpeed * Time.fixedDeltaTime), velocity.y);
                _playerRigidBody.velocity = velocity;
            }
        }
    }

    public bool IsGrabbed()
    {
        return _grabbed;
    }

    public bool IsWaiting()
    {
        return timer._doneWaiting;
    }
}
