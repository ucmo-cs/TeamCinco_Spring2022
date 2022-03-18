using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float speed = 15f;
    public TokenController tokenController;
    public DashState dashState;

    private Rigidbody2D _playerRigidBody;
    private Camera _cam;

    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return; // can't use OnMouseDown, that only triggers when inside collider
        if (dashState != DashState.Ready) return; 
        if (!tokenController.HasTokens()) return; 
        tokenController.UseToken();
        var mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition); 
        var moveDirection = transform.position - mousePosition;
        moveDirection.z = 0;
        _playerRigidBody.AddForce(-moveDirection.normalized * speed, ForceMode2D.Impulse);
        dashState = DashState.Dashing;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (dashState != DashState.Dashing) return;
        if (col.gameObject.CompareTag("Destructible")) Destroy(col.gameObject);
        dashState = DashState.Ready;
    }
}

public enum DashState
{
    Ready,
    Dashing
}