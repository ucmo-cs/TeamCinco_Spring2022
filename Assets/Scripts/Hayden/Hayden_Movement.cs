//Hayden White
//Last Update: April 4th, 2022
//This is the movement script for my first level.

//If you see GFZ, that is in reference to a Gravity-Flippable Zone.

using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Hayden_Movement : MonoBehaviour
{
    private Rigidbody2D player;

    public bool flipGrav = false;

    public bool grounded;

    [SerializeField] public int jumpCount = 0;
    //This is serialized so I can make sure the jump count is being tallied accurately.

    public int CPjumpCount = 0;
    //This keeps track of the players' jump count at each checkpoint.

    public TextMeshProUGUI textTokens;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        const float walkingSpeed = 15;
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            if(!flipGrav || player.gravityScale == 1)
            {
                player.velocity = new Vector2(player.velocity.x, walkingSpeed / 2);
                // Tells the diamond to jump, but only if it has a jump token.
            }

            else if(flipGrav)
            {
                player.velocity = new Vector2(player.velocity.x, -walkingSpeed / 2);
                // Tells the diamond to jump in a downwards direction, but only if it has a jump token.
            }
            
            jumpCount--;
            // Decreases the jump counter.
            textTokens.text = jumpCount.ToString();
        }

        if(Input.GetMouseButtonDown(0) && flipGrav && grounded)
        {
            player.gravityScale *= -1;
            //This is what actually flips the gravity.
        }
        //This checks if the player is trying to flip the gravity of the level.

        if(Input.GetKeyDown(KeyCode.R))
        {
            jumpCount = CPjumpCount;
            textTokens.text = jumpCount.ToString();
        }
    }
    //Everything in "Update()" must be checked as often as possible so there is no lag between button press and player movement.
    /*
    Things handled in "Update()":
        Jumping
        Gravity Shifting
    */

    private void FixedUpdate()
    {
        const float walkingSpinSpeed = 8000;
        const float walkingSpeed = 15;

        if(!flipGrav || player.gravityScale == 1)
        {
            if (Input.GetKey(KeyCode.A) && player.angularVelocity < 800) // LEFT
            {
                player.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.D) && player.angularVelocity > -800) // RIGHT
            {
                player.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
            }
        }
        //This handles player rotation if gravity is normal.

        else if(flipGrav && player.gravityScale == -1)
        {
            if (Input.GetKey(KeyCode.A) && player.angularVelocity > -800) // LEFT
            {
                player.angularVelocity -= walkingSpinSpeed * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.D) && player.angularVelocity < 800) // RIGHT
            {
                player.angularVelocity += walkingSpinSpeed * Time.fixedDeltaTime;
            }
        }
        //This handles player rotation if gravity is inverted.

        if (Input.GetKey(KeyCode.A) && player.velocity.x > -5) // LEFT
        {
            var velocity = player.velocity; // cache velocity
            velocity = new Vector2(velocity.x - (walkingSpeed * Time.fixedDeltaTime), velocity.y);
            player.velocity = velocity;
        }
        //This handles the player moving to the right.

        else if (Input.GetKey(KeyCode.D) && player.velocity.x < 5) // RIGHT
        {
            var velocity = player.velocity; // cache velocity
            velocity = new Vector2(velocity.x + (walkingSpeed * Time.fixedDeltaTime), velocity.y);
            player.velocity = velocity;
        }
        //This handles player movement to the left.
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            jumpCount++;
            //This adds a jump to the player's jump counter.

            textTokens.text = jumpCount.ToString();
            //This visually shows the players' jump count.
        }
        //This determines if the player "ran into" a coin object.

        if(other.gameObject.CompareTag("Gravity"))
        { 
            flipGrav = true;
            //This tells the program that gravity can now be flipped on command.
        }
        //This determines if the player entered a zone where they can invert gravity.

        /*if(other.gameObject.CompareTag("Checkpoint"))
        {
            CPjumpCount = jumpCount;
        }*/
        //This updates the players' accumulated jump count when they hit a checkpoint.

        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Gravity"))
        {
            flipGrav = false;
            //This removes the players ability to invert gravity.

            player.gravityScale = 1;
            //This resets the player's gravity to normal.
        }
        //This checks if the player is leaving a GFZ.
    }
    //This handles the player leaving a GFZ.

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Death_Zone"))
        {
            jumpCount = CPjumpCount;
        }
        //This resets the players' jump count to the amount they had when they reached the previous checkpoint.
    
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            //Raycast to ground to compensate for natural "bumpiness".

            grounded = false;
        }
    }
}