using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private DashState _dashState;
    private Vector2 previousVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_dashState)
        {
            case DashState.Ready:
            {
                if (Input.GetMouseButtonDown(0))
                {
                    previousVelocity = _playerRigidBody.velocity;
                    // _playerRigidBody.AddForce(Input.mousePosition);
                    _playerRigidBody.AddForce(Input.mousePosition,  ForceMode2D.Force);
                    // _playerRigidBody.velocity =
                    //     new Vector2(_playerRigidBody.velocity.x * 3f, _playerRigidBody.velocity.y);
                    // _dashState = DashState.Dashing;
                }
                break;
            }
            case DashState.Dashing:
            {
                
                break;
            }
            case DashState.Cooldown:
            {
                
                break;
            }
        }
        
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}