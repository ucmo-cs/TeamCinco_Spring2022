using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float speed = 2.5f;
    public TokenController tokenController;
    public DashState dashState;

    private Rigidbody2D _playerRigidBody;
    private Camera _cam;

    public ParticleSystem dashParticles;
    public ParticleSystem breakParticles;

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
        Vector2 mousePos = Input.mousePosition;

        // Third value is distance from camera, which matters with perspective view. (by default its zero, which means it just returns the camera position each time)
        var mousePosition = _cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        var moveDirection = transform.position - mousePosition;

        _playerRigidBody.AddForce(-moveDirection * speed, ForceMode2D.Impulse);

        // create new instance of dashParticles at player position and rotation of moveDirection
        // will delete itself when finished, because Stop Action = Destroy
        Instantiate(dashParticles, transform.position, Quaternion.LookRotation(moveDirection)).Play();

        dashState = DashState.Dashing;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (dashState != DashState.Dashing) return;
        if (col.gameObject.CompareTag("Destructible"))
        {
            // create new instance of breakParticles at position and rotation of collision
            // will delete itself when finished, because Stop Action = Destroy
            Instantiate(breakParticles, col.gameObject.transform.position, col.gameObject.transform.rotation).Play();
            // Instantiate(breakParticles, col.gameObject.transform).Play(); // doesn't work because parent is going to be deleted
            // could add new script with Stop Action = callback

            Destroy(col.gameObject);
        }

        dashState = DashState.Ready;
    }
}

public enum DashState
{
    Ready,
    Dashing
}