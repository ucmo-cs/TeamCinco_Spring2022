//Hayden White
//Last Update: April 4th, 2022
//This handles the player respawn, both intentional and death-related.

using UnityEngine;

public class Hayden_Respawn : MonoBehaviour
{
    private Rigidbody2D objectRigidBody;

    private Vector2 respawnPoint = new Vector2(0, 0);

    // Start is called before the first frame update
    private void Start()
    {
        objectRigidBody = GetComponent<Rigidbody2D>();
        respawnPoint = objectRigidBody.transform.position;
    }

    //Called every frame
    private void Update() {
        if(Input.GetKeyDown(KeyCode.R))
            Respawn();
    }

    public void Respawn()
    {
        objectRigidBody.transform.position = respawnPoint;
        objectRigidBody.velocity = new Vector2();
        objectRigidBody.angularVelocity = 0;
        objectRigidBody.rotation = 0;
        objectRigidBody.gravityScale = 1;

        //Figure out how to revert jumpCount from Hayden_Movement!!!
    }

    public void SetRespawnPoint(Vector2 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }   
}