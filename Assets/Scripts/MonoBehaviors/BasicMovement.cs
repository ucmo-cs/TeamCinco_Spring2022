using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 currentVelocity;

    [SerializeField] private float movementSpeed = 3f;
    private Rigidbody2D characterRigidBody;

    // Start is called before the first frame update
    private void Start()
    {
        // Cache the Rigidbody so we don't need to keep calling it.
        characterRigidBody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal"); // X-Axis
        moveVertical = Input.GetAxis("Vertical"); // Y-Axis
        currentVelocity = characterRigidBody.velocity;
    }

    // Update is called once per physics update
    private void FixedUpdate()
    {
        if (moveHorizontal != 0)
        {
            characterRigidBody.velocity =
                new Vector2(moveHorizontal * movementSpeed, currentVelocity.y);
        }
    }
}