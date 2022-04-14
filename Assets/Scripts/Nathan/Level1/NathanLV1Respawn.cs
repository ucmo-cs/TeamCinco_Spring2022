using UnityEngine;

public class NathanLV1Respawn : MonoBehaviour
{
    private Rigidbody2D objectRigidBody;
    public Vector2 respawnPoint = new Vector2(0, 0);

    // Start is called before the first frame update
    private void Start()
    {
        objectRigidBody = GetComponent<Rigidbody2D>();
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
        GetComponent<NathanMovement>().disabled = true;
    }

    public void SetRespawnPoint(Vector2 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
    
}