using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Collider2D _anchor;
    public Rigidbody2D player;
    public GameObject playerGhost;
    
    private Vector2 _grabPoint;
    private Vector2 _grabPointOffset;
    private bool _grabbed;
    private bool _grabbedChanged;
    
    // Start is called before the first frame update
    private void Start()
    {
        _anchor = GetComponent<Collider2D>();
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

        if (!Input.GetMouseButton(0) || _grabbed) return;
        Debug.Log("Mouse Down");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!(Vector2.Distance(player.position, mousePosition) < .5))
        {
            Debug.Log("Not near Player: " + Vector2.Distance(player.position, mousePosition));
            return;
        }
        Debug.Log("Near Player");
        Debug.Log(_anchor.bounds);
        if (_anchor.bounds.Contains(mousePosition))
        {
            Debug.Log("Not near Anchor" + Vector2.Distance(_anchor.offset, mousePosition));
            return;
        }
        Debug.Log("Near anchor");
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

            if (_grabbed) // MOUSE BUTTON DOWN EVENT
            {
                // Save current grab position
                _grabPoint = player.position;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _grabPointOffset = (mousePosition - _grabPoint) / 2;
                _grabPoint.y += .5f; // This makes the player hover in the air a little bit

                // Set up player ghost
                playerGhost.gameObject.SetActive(true);
                playerGhost.GetComponent<Rigidbody2D>().position = player.position;
                playerGhost.GetComponent<Rigidbody2D>().rotation = player.rotation;
            }
            else // MOUSE BUTTON UP EVENT
            {
                // Apply velocity, capped at max value(mv).
                var v = player.velocity + playerGhost.GetComponent<Rigidbody2D>().velocity / 3;
                const float mv = 20;
                v.x = v.x > mv ? mv : v.x;
                v.x = v.x < -mv ? -mv : v.x;
                v.y = v.y > mv ? mv : v.y;
                v.y = v.y < -mv ? -mv : v.y;
                player.velocity = v;

                // Hide player ghost
                playerGhost.gameObject.SetActive(false);
            }
        }

        if (!_grabbed) return;
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
            player.angularVelocity = player.angularVelocity * .9f +
                                     (playerGhost.GetComponent<Rigidbody2D>().rotation -
                                      player.rotation);
            player.velocity = player.velocity * .9f + (_grabPoint - player.position);
        }
    }
}
