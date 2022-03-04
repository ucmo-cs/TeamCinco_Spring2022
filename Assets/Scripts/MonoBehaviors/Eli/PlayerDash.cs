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
    private void Update()
    {
        if (dashState != DashState.Ready || !Input.GetMouseButtonDown(0) || tokenController.tokenCount == 0) return;
        tokenController.UseToken();
        var mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        var moveDirection = transform.position - mousePosition;
        moveDirection.z = 0;
        _playerRigidBody.AddForce(-moveDirection.normalized * speed, ForceMode2D.Impulse);

        dashState = DashState.Dashing;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (dashState == DashState.Dashing)
        {
            dashState = DashState.Ready;
        }
    }
}

public enum DashState
{
    Ready,
    Dashing
}