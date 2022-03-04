using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float speed = 20f;
    public TokenController tokenController;
    public DashState dashState;
    
    private Rigidbody2D _playerRigidBody;
    private Camera _cam;

    // Start is called before the first frame update
    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
            {
                if (Input.GetMouseButtonDown(0) && tokenController.tokenCount != 0)
                {
                    tokenController.UseToken();
                    var mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 moveDirection = transform.position - mousePosition;
                    moveDirection.z = 0;
                    _playerRigidBody.AddForce(-moveDirection.normalized * speed, ForceMode2D.Impulse);

                    // dashState = DashState.Dashing;
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
            default: throw new ArgumentOutOfRangeException();
        }
    }
}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}