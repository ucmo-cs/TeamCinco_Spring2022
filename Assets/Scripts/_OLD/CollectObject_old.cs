//THIS SCRIPT NEEDS TO BE ADDED TO THE PLAYER IN ORDER TO RUN PROPERLY!!!

//Your token will need the tag name "Coin".

//Your actual token will simply be whatever sprite you want it to be.

using UnityEngine;
using TMPro;

public class CollectObject_old : MonoBehaviour
{
    private int tokens = 0;

    //public TextMeshProUGUI textTokens;
    //This is used to show the number of jumps a player has on screen.

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coin")){
            tokens++;
            //This adds one to the players jump counter.

            //textTokens.text = tokens.ToString();
            //This visually shows the players' jump count.

            other.GetComponent<Renderer>().enabled = false;
            other.GetComponent<Collider2D>().enabled = false;
        }

        if(other.gameObject.CompareTag("Instructions")){
            other.GetComponent<Renderer>().enabled = true;
        }
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && tokens != 0)
        {
            tokens--; // Decreases the jump counter.
            //textTokens.text = tokens.ToString();
        }
    }
}

//THE BELOW SECTIONS WILL GET ADDED TO PLAYERMOVEMENT.
//THE COMMENT BELOW THEM SAY WHERE TO ADD THEM.

/*public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin")) // Determines if the 
        {
            jumpCount++;
        }
    }
*/
//Add the above function to PlayerMovement to keep track of the player jumps.

/*    if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 0)
        {
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, walkingSpeed / 2);  // Tells the diamond to jump.
            jumpCount--; // Decreases the jump counter.
        }
*/
//Add the above if-statement to FixedUpdate to be able to jump, and decrement the counter.

//[SerializeField] public float jumpCount;
//Add this global variable to initialise jumpCount.