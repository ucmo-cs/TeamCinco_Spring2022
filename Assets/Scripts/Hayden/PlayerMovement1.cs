using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    PlayerJump playerJump;

    [SerializeField] private float speed;
    [SerializeField] public float jumpCount;
    [SerializeField] public float dashCount;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && jumpCount != 0)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            jumpCount--;
            //Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && dashCount != 0)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * 1000, body.velocity.y);
            dashCount--;
            //Jump();
        }

        if (Input.GetKey(KeyCode.UpArrow))
            RotateRight();


        void RotateRight()
        {
            transform.Rotate(Vector3.forward * -10);
        }
    }

    /*public void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        jump--;
    }*/

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Jump Token"))
        {
            jumpCount++;
        }

        if (other.gameObject.CompareTag("Dash Token"))
        {
            dashCount++;
        }
    }

    /*void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    void jump()
    {
        if (canJump)
        {
            canJump = false;
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }

    void OnCollisionEnter(Collision collidingObject)
    {
        if (collidingObject.gameObject.layer == 8)
        {
            canJump = true;
        }
    }*/
}

/*public class ObstacleTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<PlayerMovement>())
        {
            coll.gameObject.GetComponent<PlayerMovement>().ResetJumpCount();
        }
    }
}*/


//            body.velocity = new Vector2(body.velocity.x, speed);
//body.AddForce(new Vector2(body.velocity.x, speed / 10), ForceMode2D.Impulse);