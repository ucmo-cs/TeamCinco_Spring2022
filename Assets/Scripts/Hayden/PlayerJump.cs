//THIS SCRIPT NEEDS TO BE ADDED TO THE PLAYER IN ORDER TO RUN PROPERLY!!!

//Your token will need the tag name "Coin".

//Your actual token will simply be whatever sprite you want it to be.

using UnityEngine;
using UnityEngine.Serialization;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private const float WalkingSpeed = 15;

    public TokenController tokenController;
    //This is used to show the number of jumps a player has on screen.

    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !tokenController.HasTokens()) return;
        _playerRigidBody.velocity =
            new Vector2(_playerRigidBody.velocity.x, WalkingSpeed / 2); // Tells the diamond to jump.
        tokenController.UseToken(); // Decreases the jump counter.
    }
}